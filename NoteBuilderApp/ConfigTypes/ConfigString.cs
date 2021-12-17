/******************************************************************************
 * 
 * Josh Mitchell © 2021
 * 
 ******************************************************************************/

namespace NoteBulderApp.Configs
{
    public class ConfigString : BaseConfig<string>
    {
        public ConfigString(string key, string value) : base(key, value)
        {
        }
    }
}
