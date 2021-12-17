/******************************************************************************
 * 
 * Josh Mitchell © 2021
 * 
 ******************************************************************************/

namespace NoteBulderApp.Progs
{
    public interface IProg
    {
        string Selected { get; set; }

        void Run();

        bool Validate(string value);
    }
}
