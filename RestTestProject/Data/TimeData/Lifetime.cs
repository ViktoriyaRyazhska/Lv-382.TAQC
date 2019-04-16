using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Data
{
    public class Lifetime
    {
        public string Time { get; set; }

        public Lifetime()
        {
            Time = string.Empty;
        }

        public Lifetime(string time)
        {
            Time = time;
        }

        // TODO Equals
    }
}
