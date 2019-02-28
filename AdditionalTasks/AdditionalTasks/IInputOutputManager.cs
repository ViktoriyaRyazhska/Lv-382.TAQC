using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalTasks
{
    public interface IInputOutputManager
    {
        string Input();
        string Output(object o);
    }
}
