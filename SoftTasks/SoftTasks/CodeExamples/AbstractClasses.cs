using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeExamples
{
    class AbstractClasses
    {
    }

    public abstract class Vehicle
    {
        public string Name { get; private set; }
        public abstract void Move();
        public virtual void PrintName() { }
        public Vehicle(string Name)
        {
            this.Name = Name;
        }
    }

    public class Bicycle : Vehicle
    {
        public Bicycle(string Name) : base(Name) { }

        public override void Move() { }
    }
}
