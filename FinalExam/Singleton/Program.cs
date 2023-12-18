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
    /* Class: Program
    * Author: Katie Bogart
    * Purpose: Hold Player Settings Values
    * Restrictions: None
    */
    public class PlayerSettings
    {
        public string Player_Name
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
        public string License_Key
        {
            get; set;
        }
    }

    /* Class: Program
    * Author: Katie Bogart
    * Purpose: Initialize LoadSettings and SaveSettings
    * Restrictions: None
    */
    public interface IPlayerSettingsClass
    {
        PlayerSettings LoadSettings(string settingsFileName);
        void SaveSettings(PlayerSettings settings, string fileToSaveTo);
    }

    /* Class: Program
    * Author: Katie Bogart
    * Purpose: Create a single instance of PlayerSettingsClass that can LoadSettings and SaveSettings
    * Restrictions: None
    */
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

        /* Method: LoadSettings
         * Purpose: Read Json settings
         *          Deserialize Settings
         *          return settings
         * Restrictions: None
         */
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

        /* Method: SaveSettings
         * Purpose: Write Settings to a file
         * Restrictions: None
         */
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
    /* Class: Program
    * Author: Katie Bogart
    * Purpose: call Main
    * Restrictions: None
    */
    internal class Program
    {
        /* Method: Main
         * Purpose: Pull instance of singleton
         *          call load settings with filepath
         *          call save settings with filepath
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            PlayerSettingsClass playerSettingsClass = PlayerSettingsClass.GetInstance();
            PlayerSettings settings;
            string filePath = "C:\\Users\\kathe\\source\\repos\\katie-b9030\\myIGME-201\\FinalExam\\PlayerSettings.json";

            settings = playerSettingsClass.LoadSettings(filePath);

            // pulled code from ChatGPT to confirm if settings loaded correctly
            Console.WriteLine($"Player Name: {settings.Player_Name}");
            Console.WriteLine($"Level: {settings.Level}");
            Console.WriteLine($"HP: {settings.Hp}");
            Console.WriteLine($"Inventory: {string.Join(", ", settings.Inventory)}");
            Console.WriteLine($"License Key: {settings.License_Key}");

            playerSettingsClass.SaveSettings(settings, filePath);
        }
    }
}
