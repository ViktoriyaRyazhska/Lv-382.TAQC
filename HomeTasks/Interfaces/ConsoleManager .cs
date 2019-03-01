using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class ConsoleManager : IInputOutputManager
    {
        public string Input ()
        {
            Console.WriteLine("Input dog`s name");
            return Console.ReadLine(); ;
        }
        public void Output(object o)
        {
            Console.WriteLine($"Dog`s name is ");
            
        }
    }
}
