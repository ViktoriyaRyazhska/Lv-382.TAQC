using System;

namespace Codewars
{
    class ClonablePerson :ICloneable  // Singletone
    {
        private static ClonablePerson instance;

        private ClonablePerson(string Name, int Age)
        { this.Name = Name; this.Age = Age; }

        public static ClonablePerson getInstance(string name, int age)
        {
            if (instance == null)
                instance = new ClonablePerson(name, age);
            return instance;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public object Clone()
        {
            return new ClonablePerson(this.Name, this.Age);
        }

    }

}
