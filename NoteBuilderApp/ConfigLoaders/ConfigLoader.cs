/******************************************************************************
 * 
 * Josh Mitchell © 2021
 * 
 ******************************************************************************/

using NoteBulderApp.ConfigLoaders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NoteBulderApp.Configs
{
    public class ConfigLoader : IConfigLoader
    {
        public const char ConfigKeyPrefix = '[';
        public const char ConfigKeySuffix = ']';

        private List<string> _ConfigLines = new List<string>();

        public ConfigLoader(string configPath)
        {
            this.ConfigPath = configPath;
        }

        public string ConfigPath { get; private set; }

        public List<ConfigString> Configs { get; private set; } = new List<ConfigString>();

        public static IConfigLoader LoadConfig(string configPath)
        {
            var configLoader = new ConfigLoader(configPath);
            configLoader.Validate();
            configLoader.ReadLines();
            configLoader.ParseLines();
            return configLoader;
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.ConfigPath))
                throw new ArgumentNullException(nameof(this.ConfigPath));

            if (!File.Exists(this.ConfigPath))
                throw new ArgumentOutOfRangeException(nameof(this.ConfigPath));
        }

        private void ReadLines()
        {
            this._ConfigLines = File.ReadAllLines(this.ConfigPath)
                .Select(s => s?.Trim() ?? string.Empty)
                .Where(s => !string.IsNullOrWhiteSpace(s)
                         && this.ValidateLine(s))
                .ToList();
        }

        private bool ValidateLine(string line)
        {
            line = (line ?? string.Empty).Trim();
            bool valid = true;
            valid &= (line.Count(c => (c == ConfigKeyPrefix)) <= 1);
            valid &= (line.Count(c => (c == ConfigKeySuffix)) <= 1);
            return valid;
        }

        private void ParseLines()
        {
            string currentKey = string.Empty;
            for (int i = 0; i < this._ConfigLines.Count; i++)
            {
                string line = this._ConfigLines[i];
                if (line.StartsWith(ConfigKeyPrefix) && line.EndsWith(ConfigKeySuffix))
                    currentKey = FormatConfigKey(line);
                else
                    this.Configs.Add(new ConfigString(currentKey, line));

            }
        }

        private static string FormatConfigKey(string key)
        {
            return key?.TrimStart(ConfigKeyPrefix)?.TrimEnd(ConfigKeySuffix);
        }
    }
}
