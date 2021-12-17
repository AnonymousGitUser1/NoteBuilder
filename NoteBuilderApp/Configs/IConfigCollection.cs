/******************************************************************************
 * 
 * Josh Mitchell © 2021
 * 
 ******************************************************************************/

using System.Collections.Generic;

namespace NoteBulderApp.Configs
{
    public interface IConfigCollection<T>
    {
        string Key { get; }

        IEnumerable<T> Values { get; }

        void Validate();
    }
}
