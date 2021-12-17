/******************************************************************************
 * 
 * Josh Mitchell © 2021
 * 
 ******************************************************************************/

using System;
using System.IO;

namespace NoteBulderApp.Configs
{
    public class ConfigPathCollection : ConfigStringCollection
    {
        public override void Validate()
        {
            foreach (string v in this.Values ?? Array.Empty<string>())
                if (!Directory.Exists(v) && !File.Exists(v))
                    throw new ArgumentOutOfRangeException("Invalid path");
            
        }
    }
}
