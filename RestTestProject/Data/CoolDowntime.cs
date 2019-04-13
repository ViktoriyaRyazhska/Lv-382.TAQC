using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Data
{
    public class CoolDowntime
    {
        public string Time { get; set; }

        public CoolDowntime()
        {
            Time = string.Empty;
        }

        public CoolDowntime(string time)
        {
            Time = time;
        }

    }
}
