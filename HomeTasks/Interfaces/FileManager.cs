using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class FileManager : IInputOutputManager
    {
        public string Input()
        {
            try
            {               
                using (StreamReader sr = new StreamReader(filename))
                {
                    return (sr.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                return (e.Message);
            }
        }
        public void Output(object o)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    sw.WriteLine();
                }              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private string filename = " ";
    }
}
