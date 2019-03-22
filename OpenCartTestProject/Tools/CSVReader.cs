using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTestProject.Tools
{
    class CSVReader : AExternalReader
    {
        private const char CSV_SPLIT_BY = ';';

        public CSVReader(string filename) : base(filename)
        {
        }

        public override IList<IList<string>> GetAllCells(string path)
        {
            IList<IList<string>> allCells = new List<IList<string>>();
            string row;
            //
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    while ((row = streamReader.ReadLine()) != null)
                    {
                        allCells.Add(row.Split(CSV_SPLIT_BY).ToList());
                    }
                }
            }
            catch
            {
                // TODO
                //log.Error("File " + path + " not Found");
            }
            return allCells;
        }

    }
}
