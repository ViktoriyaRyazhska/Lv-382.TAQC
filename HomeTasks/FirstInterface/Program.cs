using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstInterface
{
    class Dog : ICloneable
    {
        private int year;
        private string name;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Dog(int year, string name)
        {
            this.year = Year;
            this.name = Name;
        }
        public object Clone()
        {
            return new Dog(this.year, this.name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog(10,"shd");
            Dog[] dogs = new Dog[10];
            for (int i = 0; i < 10; i++)
            {
                dogs[i] = (Dog)dog.Clone();
            }
        }
    }
}
