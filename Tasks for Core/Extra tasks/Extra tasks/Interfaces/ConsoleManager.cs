using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks.Interfaces
{
    public class ConsoleManager : IInputOutputManager
    {
        string IInputOutputManager.Input()
        {
            string n = Console.ReadLine();
            return n;
        }

        void IInputOutputManager.Output(object o)
        {
            Console.WriteLine(o.ToString());
        }
    }
}
