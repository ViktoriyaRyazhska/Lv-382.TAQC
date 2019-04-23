using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppOpenCart.Wrapper
{
    public class Box2<T>
    {
        private T data;

        public T Get()
        {
            return data;
        }

        public void Set(T data)
        {
            this.data = data;
        }
    }
}
