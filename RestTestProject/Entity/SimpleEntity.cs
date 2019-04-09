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

        public SimpleEntity() // for T result = default(T); from class RestCrud<T>
        {
        }

        public override string ToString()
        {
            return content;
        }
    }
}
