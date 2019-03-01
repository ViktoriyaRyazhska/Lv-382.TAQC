using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks.Interfaces
{
    public class Doctor : ICloneable
    {
        private string name;
        private int age;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public object Clone()
        {
            return new Doctor { Name = this.Name, Age = this.Age };
        }
        
        
    }
}
