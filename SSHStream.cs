using System;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Renci.SshNet;

namespace rtssh
{
    internal static class SSHStream
    {
        public static void Start(string username, string host, int port, string keyPath, string jsonPath)
        {
            // Run RTSS or hook to existing process
            RTSSHandler.RunRTSS();
            var key = new PrivateKeyFile(keyPath);
            var sshClient = new SshClient(host, port, username, key);
            sshClient.Connect();
            
            // Stream sensors -j
            var shellStream = sshClient.CreateShellStream("rtssh", 
                0, 0, 0, 0, 1024);
            const string command = "while true; do sensors -j | jq -cM; sleep 1; done";
            shellStream.WriteLine(command);

            while (true)
            {
                // Save ssh output into string
                var temp = shellStream.Read();
                
                // Export total cpu temp from ssh output
                try
                {
                    if (temp.Length > 0 && temp.StartsWith("{"))
                    {
                        var jsonTemp = JObject.Parse(temp);
                        // Split jsonPath with , into a string Array
                        var jsonPathFormatted = JsonPathFormatter(jsonPath);
                        var formattedTemp = "CPU:   " +
                                            (int) (double) jsonTemp
                                                    [jsonPathFormatted[0]] ?
                                                    [jsonPathFormatted[1]] ?
                                                    [jsonPathFormatted[2]] +
                                            "";
                        
                        // Print cpu temp into RTSS
                        RTSSHandler.Print(formattedTemp);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    sshClient.Disconnect();
                    break;
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