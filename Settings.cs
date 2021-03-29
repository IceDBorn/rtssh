namespace rtssh
{
    public static class Settings
    {
        public static void Save(string username, string host, string port, string key, bool autoConnect)
        {
            // Change each setting with user's value
            Properties.Settings.Default["Username"] = username;
            Properties.Settings.Default["Host"] = host;
            Properties.Settings.Default["Port"] = port;
            Properties.Settings.Default["Key"] = key;
            Properties.Settings.Default["autoConnect"] = autoConnect;
            Properties.Settings.Default["saveSettings"] = true;
            Properties.Settings.Default.Save();
        }

        public static void Clear()
        {
            // Revert all settings back to default values
            Properties.Settings.Default["Username"] = "";
            Properties.Settings.Default["Host"] = "";
            Properties.Settings.Default["Port"] = "22";
            Properties.Settings.Default["Key"] = "id_rsa";
            Properties.Settings.Default["autoConnect"] = false;
            Properties.Settings.Default["saveSettings"] = false;
            Properties.Settings.Default.Save();
        }
    }
}