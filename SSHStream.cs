using System;
using System.Threading;
using Newtonsoft.Json.Linq;
using Renci.SshNet;

namespace rtssh
{
    internal static class SSHStream
    {
        private static void Main(string[] args)
        {
            // Run RTSS or hook to existing process
            RTSSHandler.RunRTSS();
            
            // Connect to SSH Client
            var key = new PrivateKeyFile("id_rsa");
            const string username = "icedborn";
            const string host = "192.168.122.1";
            const int port = 22;
            var sshClient = new SshClient(host, port, username, key);
            sshClient.Connect();
            Console.WriteLine("Connected to SSH Client as " + username);
            
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
                        var formattedTemp = "CPU:   " +
                                                (int) (double) jsonTemp
                                                ["k10temp-pci-00c3"] ?
                                                ["Tctl"] ?
                                                ["temp1_input"] +
                                                "";
                        
                        // Print cpu temp into RTSS
                        RTSSHandler.Print(formattedTemp);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                // Wait for 1 second before updating the cpu temp
                Thread.Sleep(1000);
            }
        }
    }
}