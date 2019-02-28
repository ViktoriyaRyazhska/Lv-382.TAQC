using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.ClassesInterfaces
{
    interface IInputOutputManager
    {
        string Input();
        void Output(object obj);
    }
}
