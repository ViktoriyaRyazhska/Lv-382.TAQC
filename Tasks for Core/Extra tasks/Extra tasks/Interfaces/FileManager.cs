using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks.Interfaces
{
    public class FileManager:IInputOutputManager
    {
        string filename = "f.txt";

        public string Input()
        {
            string n = Console.ReadLine();
            return n;
        }

        public void Output(object o)
        {
            Console.WriteLine(o.ToString());
        }
    }
}
