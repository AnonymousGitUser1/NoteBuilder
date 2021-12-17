/******************************************************************************
 * 
 * Josh Mitchell © 2021
 * 
 ******************************************************************************/

using System.Collections.Generic;

namespace NoteBulderApp.Configs
{
    public abstract class BaseConfigCollection<T> : IConfigCollection<T>
    {
        public string Key { get; set; }

        public IEnumerable<T> Values { get; set; }

        public virtual void Validate()
        {
            return; /* degenerate */
        }
    }
}
