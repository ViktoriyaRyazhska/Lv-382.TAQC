using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Entity
{
    public class SimpleEntity
    {
        public string content { get; set; }

        public SimpleEntity()
        {
        }

        public override string ToString()
        {
            return content;
        }
    }
}
