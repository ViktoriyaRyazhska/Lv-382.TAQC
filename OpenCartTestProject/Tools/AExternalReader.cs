using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTestProject.Tools
{
    public abstract class AExternalReader
    {
        public const int PATH_PREFIX = 6;
        public const string PATH_SEPARATOR = "\\";
        protected const string FOLDER_DATA = "Resources";
        protected const string FOLDER_BIN = "bin";
        //
        //public static Logger log = LogManager.GetCurrentClassLogger(); // for NLog

        public string Filename { get; private set; }
        public string Path { get; protected set; }

        //protected ExternalReader(string filename)
        public AExternalReader(string filename)
        {
            Filename = filename;
            Path = AppDomain.CurrentDomain.BaseDirectory;
            Path = Path.Remove(Path.IndexOf(FOLDER_BIN)) + FOLDER_DATA + PATH_SEPARATOR + filename;
            Console.WriteLine("***PATH to resource: " + Path);
        }

        public IList<IList<string>> GetAllCells()
        {
            return GetAllCells(Path);
        }

        public abstract IList<IList<string>> GetAllCells(string path);

    }
}
