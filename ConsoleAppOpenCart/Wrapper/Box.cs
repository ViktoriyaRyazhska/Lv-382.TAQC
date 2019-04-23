using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppOpenCart.Wrapper
{
    public class Box
    {
        private object data;

        public object Get()
        {
            return data;
        }

        public void Set(object data)
        {
            this.data = data;
        }
    }
}
