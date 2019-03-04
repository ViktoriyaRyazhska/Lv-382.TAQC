using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace ClassesCSharp
{

    public enum WindStrength
    {
        [Description("calm")] t,
        [Description("light")] l,
        [Description("moderate")] p,
        [Description("strong")] s
    }

    public enum Precipitation
    {
        [Description("no precipitation")] NoPresipitation = 0,
        [Description("rain")] Rain,
        [Description("snow")] Snow
    }

    public class Forecast : ICloneable
    {
        public object Enums { get; private set; }
        public int Temperature { get; set; }
        public int AtmosphPressure { get; set; }
        public WindStrength WindStrength { get; set; }
        public Precipitation Precipitation { get; set; }

        public Forecast() { }
        public Forecast(int Temperature, int AtmosphPressure, WindStrength WindStrength, Precipitation Precipitation)
        {
            this.Temperature = Temperature;
            this.AtmosphPressure = AtmosphPressure;
            this.WindStrength = WindStrength;
            this.Precipitation = Precipitation;
        }

        public override string ToString()
        {
            return string.Format("{0, -16}{1, -14}{2, -16}{3, -19}", Temperature + "'C", AtmosphPressure,
                WindStrength.DescriptionAttr(), Precipitation.DescriptionAttr());
        }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Forecast f = (Forecast)obj;
                return (Temperature == f.Temperature) && (AtmosphPressure == f.AtmosphPressure
                    && WindStrength == f.WindStrength && Precipitation == f.Precipitation);
            }
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public void Write()
        {
            Console.WriteLine("Input temperature: ");
            Temperature = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input atmosphere pressure: ");
            AtmosphPressure = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input wind strength: ");
            Console.Write(@"
                            t - Calm
                            l - Light
                            p - Moderate
                            p - Strong

                            Please select one (t, l, p or s): ");
            WindStrength = (WindStrength)Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Input precipitation: ");
            Console.Write(@"
                            0 - No precipitation
                            1 - Rain
                            2 - Snow

                            Please select one (0, 1 or 2): ");
            Precipitation = (Precipitation)(Int32.Parse(Console.ReadLine()));
        }

        public object Clone()
        {
            return new Forecast(Temperature, AtmosphPressure,WindStrength,Precipitation);
        }
               
    }


}
