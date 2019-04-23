using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppOpenCart.Wrapper
{
    public class BoxWrapper
    {
        private Box box;

        public BoxWrapper()
        {
            box = new Box();
        }

        public string Get()
        {
            return (string)box.Get(); // Feature
        }

        public void Set(string data)
        {
            box.Set(data);
        }
    }
}
