/******************************************************************************
 * 
 * Josh Mitchell © 2021
 * 
 ******************************************************************************/

using NoteBulderApp.ConfigLoaders;
using NoteBulderApp.Configs;
using System;
using System.Linq;

namespace NoteBulderApp.ConfigItems
{
    public class NoteConfig
    {
        private const string FolderPathsKey = "FolderPaths";

        private IConfigLoader _ConfigLoader;

        public NoteConfig(IConfigLoader configLoader)
        {
            this._ConfigLoader = configLoader ?? throw new ArgumentNullException(nameof(configLoader));
            
            this.Initialise();
        }

        public ConfigPathCollection Paths { get; set; }

        private void Initialise()
        {
            this.InitialisePaths();
        }

        private void InitialisePaths()
        {
            this.Paths = new ConfigPathCollection();
            this.Paths.Key = FolderPathsKey;
            this.Paths.Values = this._ConfigLoader.Configs
                .Where(c => c.Key == FolderPathsKey)
                .Select(c => c.Value);
        }
    }
}
