/******************************************************************************
 * 
 * Josh Mitchell © 2021
 * 
 ******************************************************************************/

namespace NoteBulderApp.Configs
{
    public interface IConfig<T>
    {
        string Key { get; }
        
        T Value { get; }

        void Validate();
    }
}
