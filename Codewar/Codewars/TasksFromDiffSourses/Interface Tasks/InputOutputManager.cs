using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Codewars
{
    interface InputOutputManager
    {
        string input();
        void output(object o);
    }
    class ConsoleManager : InputOutputManager
    {
        public string input()
        {
            Console.WriteLine("Input value: ");
            return Console.ReadLine();
        }
        public void output(object o)
        {
            Console.WriteLine($"Output value: {o.ToString()}");
        }
    }
    class FileManager : InputOutputManager
    {
        public string FilePath { get; set; }
        public string input()
        {
            using (FileStream fstream = File.OpenRead(FilePath))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                return  textFromFile;
            }

        }
        public void output(object o)
        {
            using (FileStream fstream = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(o.ToString());
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }
        }

    }
}
