# Prerequisites
1. SSH
2. SSH Private key
3. lm-sensors
4. <a href="https://www.guru3d.com/files-details/rtss-rivatuner-statistics-server-download.html" target="_blank">RivaTuner Statistics Server</a>
5. <a href="https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net472-web-installer" target="_blank">.NET Framework 4.7.2</a>

# How to use
<b>Linux</b>
1. Open a terminal and run "sudo systemctl start sshd"
2. Run "systemctl enable sshd"
3. Run "ssh-keygen" to generate a private key file
4. Move private key file to Windows, usually located in "~/.ssh/" as "id_rsa"
5. Install lm-sensors
6. Open a terminal and run "sensors -j"
7. Based on the output, add the corresponding JSON cells path, seperated by commas, for the temp you want to monitor into "JSON Path" (Windows, Step 8)

<b>Windows</b>
1. Install RivaTuner
2. Open RTSSH
3. Check the settings you want to use under "Settings" section
4. Fill in host user's name
5. Fill host address, usually "192.168.122.1" for Windows VMs
6. Fill port, usually "22"
7. Browse for the private key file
8. If "both" or "temperature" are selected under "Display", fill JSON Path (Linux, Step 7), otherwise go to next step
9. Press Connect


<b>Example:</b>

<img src="https://i.imgur.com/KgNEiLW.png" width="700" height="700">

# Credits
1. <b>damob-byun</b> for <a href="https://github.com/damob-byun/OpenRtssText" target="_blank">OpenRtssText</a> 
2. <b>sshnet</b> for <a href="https://github.com/sshnet/SSH.NET/" target="_blank">SSH.NET</a>
