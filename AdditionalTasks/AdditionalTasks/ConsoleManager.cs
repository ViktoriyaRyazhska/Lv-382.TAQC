using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalTasks
{
    public class ConsoleManager : IInputOutputManager
    {
        public string Input()
        {
            Console.WriteLine("Please enter car's model:");
            return Console.ReadLine();  
        }

        public string Output(object o)
        {
            if (o is Car)
            {
                Car temp = (Car)o;
                return $"{temp.model}'s top speed is {temp.topSpeed}. Woooow";
            }
            else
            {
                return "Entered object is not a car. It's " + o.GetType();
            }
        }
    }
}
