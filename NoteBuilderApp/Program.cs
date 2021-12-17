/******************************************************************************
 * 
 * Josh Mitchell © 2021
 * 
 ******************************************************************************/

using NoteBulderApp.ConfigLoaders;
using NoteBulderApp.Configs;
using NoteBulderApp.ProgItems;
using NoteBulderApp.StaticData;
using System.IO;

namespace NoteBulderApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunNoteProgram();
        }

        private static void RunNoteProgram()
        {
            NoteProg noteProg = new NoteProg(GetUserSettingsConfig());
            noteProg.Run();
        }

        private static IConfigLoader GetUserSettingsConfig()
        {
            string configPath = Path.Combine(Directory.GetCurrentDirectory(), Lookups.ConfigPath);
            return ConfigLoader.LoadConfig(configPath);
        }
    }
}
