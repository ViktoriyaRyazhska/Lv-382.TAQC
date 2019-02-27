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

    public class Forecast
    {
        private int Temperature { get; set; }
        private int AtmosphPressure { get; set; }
        private WindStrength WindStrength { get; set; }
        private Precipitation Precipitation { get; set; }
        public object Enums { get; private set; }

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
            return Temperature + "'C" + "\t" + AtmosphPressure + "\t" +
                WindStrength + "\t" + Precipitation;
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
            Console.WriteLine(Temperature + "'C" + "\t" + AtmosphPressure + "\t" +
                WindStrength + "\t" + Precipitation);
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


        public static string DescriptionAttr<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

    }


}
