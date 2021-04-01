namespace rtssh
{
    public static class Settings
    {
        public static void Save(string username, string host, string port, string key, string jsonPath, bool autoConnect, string tempText, string freqText, bool separatorComma, int displayToggle)
        {
            // Change each setting with user's value
            Properties.Settings.Default["username"] = username;
            Properties.Settings.Default["host"] = host;
            Properties.Settings.Default["port"] = port;
            Properties.Settings.Default["key"] = key;
            Properties.Settings.Default["jsonPath"] = jsonPath;
            Properties.Settings.Default["autoConnect"] = autoConnect;
            Properties.Settings.Default["saveSettings"] = true;
            Properties.Settings.Default["tempText"] = tempText;
            Properties.Settings.Default["freqText"] = freqText;
            Properties.Settings.Default["separatorComma"] = separatorComma;
            Properties.Settings.Default["displayToggle"] = displayToggle;
            Properties.Settings.Default.Save();
        }

        public static void Clear()
        {
            // Revert all settings back to default values
            Properties.Settings.Default["Username"] = "";
            Properties.Settings.Default["Host"] = "192.168.122.1";
            Properties.Settings.Default["Port"] = "22";
            Properties.Settings.Default["Key"] = "id_rsa";
            Properties.Settings.Default["jsonPath"] = "";
            Properties.Settings.Default["autoConnect"] = false;
            Properties.Settings.Default["saveSettings"] = false;
            Properties.Settings.Default["tempText"] = "CPU ";
            Properties.Settings.Default["freqText"] = "CPU ";
            Properties.Settings.Default["separatorComma"] = true;
            Properties.Settings.Default["displayToggle"] = 2;
            Properties.Settings.Default.Save();
        }
    }
}