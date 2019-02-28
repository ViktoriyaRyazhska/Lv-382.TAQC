using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.Util
{
    class InputOutput
    {
        public static bool TryLoop<R>(Func<string, R> func, out R result)
        {
            string input;
            do
            {
                input = Console.ReadLine();
                try
                {
                    result = func(input);
                    return true;
                }
                catch
                {
                    Console.WriteLine("Bad input, please try again:");
                }
            }
            while (input != "q");

            result = default(R);
            return false;
        }
    }
}
