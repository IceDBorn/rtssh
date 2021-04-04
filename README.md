# Prerequisites
1. <a href="https://www.ubuntupit.com/how-to-install-configure-and-enable-ssh-service-in-linux/">SSH</a>
2. <a href="https://www.howtogeek.com/424510/how-to-create-and-install-ssh-keys-from-the-linux-shell/">SSH Private key</a>
3. <a href="https://linoxide.com/install-lm-sensors-linux/">lm-sensors</a>
4. <a href="https://www.guru3d.com/files-details/rtss-rivatuner-statistics-server-download.html" target="_blank">RivaTuner Statistics Server</a>
5. <a href="https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net472-web-installer" target="_blank">.NET Framework 4.7.2</a>

# How to use
<b>Linux</b>
1. Move private key file to Windows, usually located in `~/.ssh/` as `id_rsa`
2. Open a terminal and run `sensors -j > sensors.json`
3. Move sensors.json to Windows

<b>Windows</b>
1. Open RTSSH
2. Check the settings you want to use under `Settings` section
3. Fill in host user's name
4. Fill host address, usually `192.168.122.1` for QEMU/KVM VMs
5. Fill port, usually `22`
6. Browse for the private key file
7. If `both` or `temperature` is selected under `Display`, browse for `sensors.json` and select temperature to print, otherwise go to the next step
8. Press Connect

# Credits
1. <b>damob-byun</b> for <a href="https://github.com/damob-byun/OpenRtssText" target="_blank">OpenRtssText</a> 
2. <b>sshnet</b> for <a href="https://github.com/sshnet/SSH.NET/" target="_blank">SSH.NET</a>
