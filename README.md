# Prerequisites
1. <a href="https://www.ubuntupit.com/how-to-install-configure-and-enable-ssh-service-in-linux/" target="_blank">SSH</a>
2. <a href="https://linoxide.com/install-lm-sensors-linux/" target="_blank">lm-sensors</a>
3. <a href="https://www.guru3d.com/files-details/rtss-rivatuner-statistics-server-download.html" target="_blank">RivaTuner Statistics Server</a>
4. <a href="https://gitforwindows.org/" target="_blank">Git for Windows</a>
5. <a href="https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net472-web-installer" target="_blank">.NET Framework 4.7.2</a>
6. <a href="https://aka.ms/vs/16/release/vc_redist.x64.exe" target="_blank">Microsoft Visual C++ Redistributables 2015-2019</a>


# How to use
<b>Linux</b>
1. Open a terminal and run `sensors -j > sensors.json`
2. Move sensors.json to Windows

<b>Windows</b>
1. Open `powershell`
2. Run `ssh-keygen`, press enter until the key's created
3. Open `Git Bash`
4. Run `ssh-copy-id user@host` (`user` = <YOUR_LINUX_USERNAME> - `host` = <IP_ADDRESS_OF_LINUX_HOST>, usually `192.168.122.1` for QEMU/KVM VMs)
5. Open RTSSH
6. Check the settings you want to use under `Settings` section
7. Fill `user`
8. Fill `host`
9. Fill `port`, usually `22`
10. Browse for the private key file, usually located at `C:\Users\<USERNAME>\.ssh` as `id_rsa`
11. If `both` or `temperature` is selected under `Display`, browse for `sensors.json` and select temperature to print, otherwise go to the next step
12. Press Connect

# Credits
1. <b>damob-byun</b> for <a href="https://github.com/damob-byun/OpenRtssText" target="_blank">OpenRtssText</a> 
2. <b>sshnet</b> for <a href="https://github.com/sshnet/SSH.NET/" target="_blank">SSH.NET</a>
