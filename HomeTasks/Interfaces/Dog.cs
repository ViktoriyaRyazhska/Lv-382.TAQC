using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Dog 
    {
        public string Name { get { return Name; } set { Name = value; } }
        public int Year { get { return Year; } set { Year = value; } }
        public Dog (string name, int year)
        {
            this.Name = name;
            this.Year = year;
        }

    }
}
