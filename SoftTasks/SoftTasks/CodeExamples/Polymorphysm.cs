using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeExamples
{
    class Polymorphysm
    {
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

    //Overriding
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
    
}
