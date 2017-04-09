using LinusForumTips.Extra_Classes.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinusForumTips.Extra_Classes.Settings
{
    class Config
    {

        static Windows.Storage.ApplicationDataContainer localSettings;
        static Windows.Storage.StorageFolder localFolder;


        public Config()
        {
            localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        }

        public void addDefault(string key, object value)
        {
            var toAdd = value.ToString();
            localSettings.Values[key] = toAdd;
        }

        public string getString(string key)
        {
            if (localSettings.Values[key] == null) throw new NoSuchSettingException("No such setting exists: " + key);
            var value = localSettings.Values[key];
            return value.ToString();
        }

        public int getInt(string key)
        {
            if (localSettings.Values[key] == null) throw new NoSuchSettingException("No such setting exists: " + key);
            var value = localSettings.Values[key];
            return int.Parse(value.ToString());
        }

        public float getFloat(string key)
        {
            if (localSettings.Values[key] == null) throw new NoSuchSettingException("No such setting exists: " + key);
            var value = localSettings.Values[key];
            return float.Parse(value.ToString());
        }

        public bool getBool(string key)
        {
            if (localSettings.Values[key] == null) throw new NoSuchSettingException("No such setting exists: " + key);
            var value = localSettings.Values[key];
            return Boolean.Parse(value.ToString());
        }


        /**public string getBackgroundURLSave()
        {
            return (string) localSettings.Values["background"];
        }

        public void saveBackgroundLink(string url)
        {
            localSettings.Values["background"] = url;
        }*/

    }
}
