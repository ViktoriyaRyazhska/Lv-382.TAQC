using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.ClassesInterfaces
{
    class ConsoleManager : IInputOutputManager
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
