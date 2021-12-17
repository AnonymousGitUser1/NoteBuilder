/******************************************************************************
 * 
 * Josh Mitchell © 2021
 * 
 ******************************************************************************/

using NoteBulderApp.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteBulderApp.Progs
{
    public class ProgCollection : IProg
    {
        private IEnumerable<string> _Values;

        public ProgCollection(IEnumerable<string> values)
        {
            this._Values = values ?? new string[0];
        }

        public string Selected { get; set; }

        public void Run()
        {
            Console.WriteLine("Select Path");

            for (int i = 0; i < this._Values.Count(); i++)
                Console.WriteLine($"{i} - {this._Values.ElementAt(i)}");

            string value = Console.ReadLine();

            if (this.Validate(value))
                this.Selected = value;
            else if (value == Lookups.Quit)
                return;
            else
                this.Run();
        }

        public bool Validate(string value)
        {
            int? index = this.ParseIntSafe(value);
            if ((index == null) || (index >= this._Values.Count()))
                return false;
            return true;
        }

        private int? ParseIntSafe(string value)
        {
            int v;
            return int.TryParse(value, out v) ? v : (int?)null;
        }
    }
}
