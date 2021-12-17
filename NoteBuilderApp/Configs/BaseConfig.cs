/******************************************************************************
 * 
 * Josh Mitchell © 2021
 * 
 ******************************************************************************/

using System;

namespace NoteBulderApp.Configs
{
    public class BaseConfig<T> : IConfig<T>
    {
        public BaseConfig(string key, T value)
        {
            this.Key = key ?? throw new ArgumentNullException(nameof(key));
            this.Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Key { get; set; }

        public T Value { get; set; }

        public virtual void Validate()
        {
            return; /* degenerate */
        }
    }
}
