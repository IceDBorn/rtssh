using System;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Renci.SshNet;

namespace rtssh
{
    internal static class SshStream
    {
        #region Fields
        
        private static SshClient _sshClient;
        private static ShellStream _tempStream;
        private static ShellStream _freqStream;
        private static int _displayToggle;
        private static int _refreshInterval;
        
        #endregion

        #region Constructor
        
        public static void Start(string username, string host, int port, string keyPath, string jsonPath,
            string tempText, string freqText, bool separatorFlag, int displayToggle, string refreshInterval)
        {
            _displayToggle = displayToggle;
            _refreshInterval = int.Parse(refreshInterval);
            var separatorText = separatorFlag ? "" : "\n";
            LaunchForm.MainForm.ConnectionStatus = ConnectionStatus.Connecting;

            Connect(host, port, username, keyPath);

            if (_sshClient == null || !_sshClient.IsConnected)
            {
                LaunchForm.MainForm.ConnectionStatus = ConnectionStatus.Disconnected;
                return;
            }

            ExecuteCommandOnStream();

            PrintUntilClose(separatorText, tempText, freqText, jsonPath);
        }
        
        #endregion
        
        #region Methods
        
        private static void Connect(string host, int port, string username, string keyPath)
        {
            // Run RTSS or hook to existing process
            try
            {
                RtssHandler.RunRtss();
            }
            catch
            {
                LaunchForm.MainForm.ConnectionStatus = ConnectionStatus.Disconnected;
                SystemSounds.Beep.Play();
                MessageBox.Show(@"Make sure Microsoft Visual C++ Redistributable 2015-2019 is installed!");
            }

            try
            {
                // Create key file used for connection
                var key = new PrivateKeyFile(keyPath);

                // Create ssh client with given values
                _sshClient = new SshClient(host, port, username, key);
                
                // Connect to ssh client
                _sshClient.Connect();
            }
            catch (Exception e)
            {
                LaunchForm.MainForm.ConnectionStatus = ConnectionStatus.Disconnected;
                SystemSounds.Beep.Play();
                MessageBox.Show(e.Message);
            }
        }

        private static void ExecuteCommandOnStream()
        {
            var tempCommand = "while true; do sensors -j | jq -cM; sleep " + _refreshInterval + "; done";
            var freqCommand = "while true; do lscpu -J | jq -cM; sleep " + _refreshInterval + "; done";
            
            switch (_displayToggle)
            {
                case 0:
                {
                    // Stream sensors -j
                    _tempStream = _sshClient.CreateShellStream("temp",
                        0, 0, 0, 0, 1024);

                    // Execute command
                    _tempStream.WriteLine(tempCommand);
                    break;
                }
                case 1:
                {
                    // Stream lscpu -J
                    _freqStream = _sshClient.CreateShellStream("freq",
                        0, 0, 0, 0, 1024);

                    // Execute command
                    _freqStream.WriteLine(freqCommand);
                    break;
                }
                case 2:
                {
                    // Stream sensors -j & lscpu -J
                    _tempStream = _sshClient.CreateShellStream("temp",
                        0, 0, 0, 0, 1024);
                    _freqStream = _sshClient.CreateShellStream("freq",
                        0, 0, 0, 0, 1024);

                    // Execute commands
                    _tempStream.WriteLine(tempCommand);
                    _freqStream.WriteLine(freqCommand);
                    break;
                }
            }
        }

        private static void PrintUntilClose(string separatorText, string tempText, string freqText, string jsonPath)
        {
            // Loop until form closes
            while (true)
            {
                // Convert output into JObject
                JObject jsonTemp;
                JObject freqTemp;
                string[] jsonPathFormatted = null;

                // Split jsonPath with , into a string Array
                if (!string.IsNullOrEmpty(jsonPath))
                {
                    jsonPathFormatted = JsonPathFormatter(jsonPath);
                }

                // Ready formatted text  for printing to OSD
                var formattedPrint = "";
                string tempOutput;
                string freqOutput;

                switch (_displayToggle)
                {
                    // temp
                    case 0:
                    {
                        tempOutput = _tempStream?.Read();

                        if (!string.IsNullOrEmpty(tempOutput) && tempOutput.StartsWith("{") &&
                            jsonPathFormatted != null)
                        {
                            jsonTemp = JObject.Parse(tempOutput);

                            try
                            {
                                formattedPrint = tempText + " " +
                                                 (int) (double) jsonTemp[jsonPathFormatted[0]]?[jsonPathFormatted[1]]?
                                                     [jsonPathFormatted[2]] + "°";
                            }
                            catch
                            {
                                LaunchForm.MainForm.ConnectionStatus = ConnectionStatus.Disconnected;
                                MessageBox.Show(@"Could not parse JSON");
                                return;
                            }
                        }

                        break;
                    }
                    // freq
                    case 1:
                    {
                        freqOutput = _freqStream?.Read();


                        if (!string.IsNullOrEmpty(freqOutput) && freqOutput.StartsWith("{"))
                        {
                            freqTemp = JObject.Parse(freqOutput);

                            formattedPrint = freqText + " " + (int) (double) freqTemp["lscpu"]?[16]?["data"];
                        }

                        break;
                    }
                    // both
                    case 2:
                    {
                        tempOutput = _tempStream?.Read();
                        freqOutput = _freqStream?.Read();


                        if (!string.IsNullOrEmpty(tempOutput) && tempOutput.StartsWith("{") &&
                            !string.IsNullOrEmpty(freqOutput) && freqOutput.StartsWith("{") &&
                            jsonPathFormatted != null)
                        {
                            jsonTemp = JObject.Parse(tempOutput);
                            freqTemp = JObject.Parse(freqOutput);

                            try
                            {
                                formattedPrint = tempText + " " +
                                                 (int) (double) jsonTemp[jsonPathFormatted[0]]?[jsonPathFormatted[1]]?
                                                     [jsonPathFormatted[2]] + "°" + separatorText + freqText + " " +
                                                 (int) (double) freqTemp["lscpu"]?[16]?["data"];
                            }
                            catch
                            {
                                LaunchForm.MainForm.ConnectionStatus = ConnectionStatus.Disconnected;
                                MessageBox.Show(@"Could not parse JSON");
                                return;
                            }
                        }

                        break;
                    }
                }

                if (!string.IsNullOrEmpty(formattedPrint))
                {
                    // Print cpu temp into RTSS
                    RtssHandler.Print(formattedPrint);
                    
                    if (LaunchForm.MainForm.ConnectionStatus != ConnectionStatus.Connected)
                    {
                        LaunchForm.MainForm.ConnectionStatus = ConnectionStatus.Connected;
                    }
                }
                // Wait for given seconds before updating OSD
                Thread.Sleep(_refreshInterval * 1000);
            }
        }

        private static string[] JsonPathFormatter(string jsonPath)
        {
            // Separate values
            var jsonPathFormatted = jsonPath.Split(',');

            // Trim separated values of whitespaces
            for (var i = 0; i < jsonPathFormatted.Length; i++)
            {
                jsonPathFormatted[i] = jsonPathFormatted[i].Trim();
            }

            return jsonPathFormatted;
        }
        
        #endregion
    }
}