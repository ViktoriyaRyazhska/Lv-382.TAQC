using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks.Interfaces
{
    public class ConsoleManager : IInputOutputManager
    {
        public string inp;
        public string Input()
        {
            inp = Console.ReadLine();
            return inp;
        }

        public void Output(object o)
        {
            Console.WriteLine(o.ToString());
        }
    }
}
