using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalTasks
{
    public class Car:ICloneable
    {
        private string Model;
        private int TopSpeed;
        public string model
        {
            get { return Model; }
            set { Model = value; }
        }
        public int topSpeed
        {
            get { return TopSpeed; }
            set { TopSpeed = value; }
        }
        public Car(string pmodel, int ptopSpeed=200)
        {
            model = pmodel;
            topSpeed = ptopSpeed;
        }

        public object Clone()
        {
            return new Car(this.model, this.topSpeed);
        }
    }
}
