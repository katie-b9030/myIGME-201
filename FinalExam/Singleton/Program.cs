using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Singleton
{
    public class PlayerSettings
    {
        public string PlayerName
        {
            get; set;
        }
        public int Level
        {
            get; set;
        }
        public int Hp
        {
            get; set;
        }
        public List<string> Inventory
        {
            get; set;
        }
        public string LicenseKey
        {
            get; set;
        }
    }

    public interface IPlayerSettingsClass
    {
        PlayerSettings LoadSettings(string settingsFileName);
        void SaveSettings(PlayerSettings settings, string fileToSaveTo);
    }

    public class PlayerSettingsClass : IPlayerSettingsClass
    {

        private static PlayerSettingsClass instance = new PlayerSettingsClass();

        public static PlayerSettingsClass GetInstance()
        {
            return instance;
        }

        private PlayerSettingsClass()
        {

        }

        public PlayerSettings LoadSettings(string settingsFilePath)
        {
            
            try
            {
                string settingsJson = File.ReadAllText(settingsFilePath);
                PlayerSettings settings = JsonConvert.DeserializeObject<PlayerSettings>(settingsJson);
                return settings;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when loading the setings");
                return null;
            }
        }

        public void SaveSettings(PlayerSettings settings, string fileToSaveTo)
        {
            try
            {
                File.WriteAllText(fileToSaveTo, JsonConvert.SerializeObject(settings));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when saving the settings");
            }
            
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerSettingsClass playerSettingsClass = PlayerSettingsClass.GetInstance();
            PlayerSettings settings;
            string filePath = "C:\\Users\\kathe\\source\\repos\\katie-b9030\\myIGME-201\\FinalExam\\PlayerSettings.json";

            settings = playerSettingsClass.LoadSettings(filePath);
            Console.WriteLine(settings.ToString());
            
            playerSettingsClass.SaveSettings(settings, filePath);
        }
    }
}
