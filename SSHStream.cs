using System;
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
                MessageBox.Show(e.Message);
                return;
            }

            // Connect to ssh client
            var sshClient = new SshClient(host, port, username, key);
            sshClient.Connect();

            // Stream sensors -j
            var tempStream = sshClient.CreateShellStream("temp",
                0, 0, 0, 0, 1024);
            var tempCommand = "while true; do sensors -j | jq -cM; sleep " + refreshIntervalInt + "; done";

            // Stream lscpu -J
            var freqStream = sshClient.CreateShellStream("freq",
                0, 0, 0, 0, 1024);
            var freqCommand = "while true; do lscpu -J | jq -cM; sleep " + refreshIntervalInt + "; done";

            // Execute commands on both streams
            tempStream.WriteLine(tempCommand);
            freqStream.WriteLine(freqCommand);

            // Loop until form closes
            while (true)
            {
                // Save ssh output into string
                var tempOutput = tempStream.Read();
                var freqOutput = freqStream.Read();

                // Export total cpu temp and freq from ssh output
                try
                {
                    if (tempOutput.Length > 0 && tempOutput.StartsWith("{") && freqOutput.Length > 0 &&
                        freqOutput.StartsWith("{"))
                    {
                        // Convert output into JObject
                        var jsonTemp = JObject.Parse(tempOutput);
                        var freqTemp = JObject.Parse(freqOutput);

                        // Split jsonPath with , into a string Array
                        var jsonPathFormatted = JsonPathFormatter(jsonPath);

                        // Ready formatted text  for printing to OSD
                        var formattedPrint = "";
                        switch (displayToggle)
                        {
                            // temp
                            case 0:
                            {
                                formattedPrint = tempText +
                                                 (int) (double) jsonTemp[jsonPathFormatted[0]]?[jsonPathFormatted[1]]?
                                                     [jsonPathFormatted[2]] + "°";
                                break;
                            }
                            // freq
                            case 1:
                            {
                                formattedPrint = freqText + (int) (double) freqTemp["lscpu"]?[16]?["data"];
                                break;
                            }
                            // both
                            case 2:
                            {
                                formattedPrint = tempText +
                                                 (int) (double) jsonTemp[jsonPathFormatted[0]]?[jsonPathFormatted[1]]?
                                                     [jsonPathFormatted[2]] + "°" + separatorText + freqText +
                                                 (int) (double) freqTemp["lscpu"]?[16]?["data"];
                                break;
                            }
                        }

                        // Print cpu temp into RTSS
                        RTSSHandler.Print(formattedPrint);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    sshClient.Disconnect();
                    return;
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