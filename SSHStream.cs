using System;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Renci.SshNet;

namespace rtssh
{
    internal static class SSHStream
    {
        public static void Start(string username, string host, int port, string keyPath, string jsonPath,
            string tempText, string freqText, bool separatorFlag, int displayToggle, string refreshInterval)
        {
            var separatorText = separatorFlag ? ", " : "\n";
            var refreshIntervalInt = int.Parse(refreshInterval);

            // Run RTSS or hook to existing process
            RTSSHandler.RunRTSS();

            // Create key file used for connection
            PrivateKeyFile key;
            try
            {
                key = new PrivateKeyFile(keyPath);
            }
            catch (Exception e)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show(e.Message);
                return;
            }

            // Connect to ssh client
            var sshClient = new SshClient(host, port, username, key);

            try
            {
                sshClient.Connect();
            }
            catch (Exception e)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show(e.Message);
                return;
            }

            ShellStream tempStream = null;
            ShellStream freqStream = null;

            switch (displayToggle)
            {
                case 0:
                {
                    // Stream sensors -j
                    tempStream = sshClient.CreateShellStream("temp",
                        0, 0, 0, 0, 1024);
                    var tempCommand = "while true; do sensors -j | jq -cM; sleep " + refreshIntervalInt + "; done";
                    
                    // Execute command
                    tempStream.WriteLine(tempCommand);
                    break;
                }
                case 1:
                {
                    // Stream lscpu -J
                    freqStream = sshClient.CreateShellStream("freq",
                        0, 0, 0, 0, 1024);
                    var freqCommand = "while true; do lscpu -J | jq -cM; sleep " + refreshIntervalInt + "; done";
                    
                    // Execute command
                    freqStream.WriteLine(freqCommand);
                    break;
                }
                case 2:
                {
                    // Stream sensors -j & lscpu -J
                    tempStream = sshClient.CreateShellStream("temp",
                        0, 0, 0, 0, 1024);
                    freqStream = sshClient.CreateShellStream("freq",
                        0, 0, 0, 0, 1024);
                    
                    var tempCommand = "while true; do sensors -j | jq -cM; sleep " + refreshIntervalInt + "; done";
                    var freqCommand = "while true; do lscpu -J | jq -cM; sleep " + refreshIntervalInt + "; done";
                    
                    // Execute commands
                    tempStream.WriteLine(tempCommand);
                    freqStream.WriteLine(freqCommand);
                    break;
                }
            }

            // Loop until form closes
            while (true)
            {
                // Convert output into JObject
                JObject jsonTemp;
                JObject freqTemp;

                // Split jsonPath with , into a string Array
                var jsonPathFormatted = JsonPathFormatter(jsonPath);

                // Ready formatted text  for printing to OSD
                var formattedPrint = "";
                string tempOutput;
                string freqOutput;

                switch (displayToggle)
                {
                    // temp
                    case 0:
                    {
                        tempOutput = tempStream?.Read();

                        if (!string.IsNullOrEmpty(tempOutput) && tempOutput.StartsWith("{"))
                        {
                            jsonTemp = JObject.Parse(tempOutput);

                            try
                            {
                                formattedPrint = tempText +
                                                 (int) (double) jsonTemp[jsonPathFormatted[0]]?[jsonPathFormatted[1]]?
                                                     [jsonPathFormatted[2]] + "°";
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(@"Could not parse JSON");
                                return;
                            }
                        }
                        break;
                    }
                    // freq
                    case 1:
                    {
                        freqOutput = freqStream?.Read();


                        if (!string.IsNullOrEmpty(freqOutput) && freqOutput.StartsWith("{"))
                        {
                            freqTemp = JObject.Parse(freqOutput);

                            formattedPrint = freqText + (int) (double) freqTemp["lscpu"]?[16]?["data"];
                        }
                        break;
                    }
                    // both
                    case 2:
                    {
                        tempOutput = tempStream?.Read();
                        freqOutput = freqStream?.Read();


                        if (!string.IsNullOrEmpty(tempOutput) && tempOutput.StartsWith("{") &&
                            !string.IsNullOrEmpty(freqOutput) && freqOutput.StartsWith("{"))
                        {
                            jsonTemp = JObject.Parse(tempOutput);
                            freqTemp = JObject.Parse(freqOutput);

                            try
                            {
                                formattedPrint = tempText +
                                                 (int) (double) jsonTemp[jsonPathFormatted[0]]?[jsonPathFormatted[1]]?
                                                     [jsonPathFormatted[2]] + "°" + separatorText + freqText +
                                                 (int) (double) freqTemp["lscpu"]?[16]?["data"];
                            }
                            catch (Exception e)
                            {
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
                    RTSSHandler.Print(formattedPrint);
                }

                // Wait for given seconds before updating cpu temp
                Thread.Sleep(refreshIntervalInt * 1000);
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
    }
}