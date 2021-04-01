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
            string tempText, string freqText, bool separatorFlag, int displayToggle)
        {
            var separatorText = separatorFlag ? ", " : "\n";
            // Run RTSS or hook to existing process
            RTSSHandler.RunRTSS();
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

            var sshClient = new SshClient(host, port, username, key);
            sshClient.Connect();

            // Stream sensors -j
            var tempStream = sshClient.CreateShellStream("rtssh",
                0, 0, 0, 0, 1024);
            var freqStream = sshClient.CreateShellStream("rtssh",
                0, 0, 0, 0, 1024);
            const string tempCommand = "while true; do sensors -j | jq -cM; sleep 1; done";
            const string freqCommand = "while true; do lscpu -J | jq -cM; sleep 1; done";
            tempStream.WriteLine(tempCommand);
            freqStream.WriteLine(freqCommand);

            while (true)
            {
                // Save ssh output into string
                var tempOutput = tempStream.Read();
                var freqOutput = freqStream.Read();

                // Export total cpu temp from ssh output
                try
                {
                    if (tempOutput.Length > 0 && tempOutput.StartsWith("{") && freqOutput.Length > 0 &&
                        freqOutput.StartsWith("{"))
                    {
                        var jsonTemp = JObject.Parse(tempOutput);
                        var freqTemp = JObject.Parse(freqOutput);

                        // Split jsonPath with , into a string Array
                        var jsonPathFormatted = JsonPathFormatter(jsonPath);
                        var formattedPrint = "";

                        // Ready formatted text  for printing to OSD
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

                // Wait for 1 second before updating the cpu temp
                Thread.Sleep(1000);
            }
        }

        private static string[] JsonPathFormatter(string jsonPath)
        {
            var jsonPathFormatted = jsonPath.Split(',');
            return jsonPathFormatted;
        }
    }
}