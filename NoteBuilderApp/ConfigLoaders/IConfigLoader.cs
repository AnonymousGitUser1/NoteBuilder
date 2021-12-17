/******************************************************************************
 * 
 * Josh Mitchell © 2021
 * 
 ******************************************************************************/

using NoteBulderApp.Configs;
using System.Collections.Generic;

namespace NoteBulderApp.ConfigLoaders
{
    public interface IConfigLoader
    {
        List<ConfigString> Configs { get; }
    }
}
