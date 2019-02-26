using SoftTasks.CodeWars.Level7;
using SoftTasks.CodeWars.Level8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] input = { 1, -2, 5 };
            //int expected = 6;

            //if (PositiveSum.GetPositiveSum(input) == 6)
            //{
            //    Console.WriteLine("Test passed: input {}, ex");
            //}

            MinAndMax.HighAndLow("1 2 3 4 -5");
        }
    }

    public class Methodoveloading
    {
        public long func(long a, long b)
        {
            return a + b;
        }

        public long func(long a, int b)
        {
            return a + b;
        }

        public long func(int a, long b)
        {
            return a + b;
        }

        public long func(long a, long b, long c)
        {
            return a + b + c;
        }
    }

    public interface CanFly
    {
        void Fly();
    }

    public abstract class Car
    {
        public abstract void Move();
    }

    public class FlyingCar : Car, CanFly
    {
        public void Fly()
        {
        }
        public override void Move()
        {
        }
        public virtual void Feature()
        {
        }
    }
    public class MyFlyingCar : FlyingCar
    {
        public override void Feature()
        {
        }
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

        public override void Move(){}
    }
}
