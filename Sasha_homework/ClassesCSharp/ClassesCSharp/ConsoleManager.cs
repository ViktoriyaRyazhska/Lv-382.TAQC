using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesCSharp
{
    class ConsoleManager: IInputOutputManager
    {
        public string Input()
        {
            return Console.ReadLine();
        }

        public void Output(object obj)
        {
            Console.WriteLine();
        }
    }
}
