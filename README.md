# Prerequisites
1. <a href="https://www.ubuntupit.com/how-to-install-configure-and-enable-ssh-service-in-linux/">SSH</a>
2. <a href="https://linoxide.com/install-lm-sensors-linux/">lm-sensors</a>
3. <a href="https://www.guru3d.com/files-details/rtss-rivatuner-statistics-server-download.html" target="_blank">RivaTuner Statistics Server</a>
4. <a href="https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net472-web-installer" target="_blank">.NET Framework 4.7.2</a>
5. <a href="https://gitforwindows.org/">Git for Windows</a>

# How to use
<b>Linux</b>
1. Open a terminal and run `sensors -j > sensors.json`
2. Move sensors.json to Windows

<b>Windows</b>
1. Open `Git Bash`
2. Run `ssh-keygen`, press enter until the key's created
3. Run `ssh-copy-id user@host` (`user` = <YOUR_LINUX_USERNAME> - `host` = <IP_ADDRESS_OF_LINUX_HOST>, usually `192.168.122.1` for QEMU/KVM VMs)
4. Open RTSSH
5. Check the settings you want to use under `Settings` section
6. Fill `user`
7. Fill `host`
8. Fill `port`, usually `22`
9. Browse for the private key file, located at `C:\Users\<USERNAME>\.ssh`
10. If `both` or `temperature` is selected under `Display`, browse for `sensors.json` and select temperature to print, otherwise go to the next step
11. Press Connect

# Credits
1. <b>damob-byun</b> for <a href="https://github.com/damob-byun/OpenRtssText" target="_blank">OpenRtssText</a> 
2. <b>sshnet</b> for <a href="https://github.com/sshnet/SSH.NET/" target="_blank">SSH.NET</a>
