using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalTasks
{
    public class FileManager : IInputOutputManager
    {
        private string filename = @"..\CarInfo.txt";
        public string Input()
        {
            try
            {
                using (StreamReader reader = new StreamReader(new FileStream(filename, FileMode.Open, FileAccess.Read)))
                {
                    return reader.ReadLine();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Output(object o)
        {
            bool error = false;
            try
            {
                if (o is Car)
                {
                    Car temp = (Car)o;
                    using (StreamWriter writer = File.AppendText(filename))
                    {
                        writer.WriteLine($"{temp.model}'s top speed is {temp.topSpeed}. Woooow");
                    }
                }
            }
            catch (Exception ex)
            {
                error = true;
            }
            return error ? "Writing to file failed" : "Writing to file was successful";

        }
    }
}
