using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalTasks
{
    public class SingleForecast
    {
        public double Temperature { get; set; }
        public short Pressure { get; set; }
        public Wind Windiness { get; set; }
        public Fallout FalloutType { get; set; }
        public enum Wind
        {
            Strong = 4,
            Mild = 3,
            Light = 2,
            NoWind = 1
        };
        public enum Fallout
        {
            NoFallout = 0,
            Rain = 1,
            Snow = 2
        };
        public SingleForecast()
        {
        }
        public SingleForecast(double temp,short press,Wind wind,Fallout fallout)
        {
            this.Temperature = temp;
            this.Pressure = press;
            this.FalloutType = fallout;
            this.Windiness = wind;
        }
    }
    public class WeatherForecast
    {
        private List<SingleForecast> Forecasts = new List<SingleForecast>();
        public List<SingleForecast> forecasts
        {
            get { return Forecasts; }
            set { Forecasts = value; }
        }
        public WeatherForecast()
        {
        }
        public WeatherForecast(double temp,short press, SingleForecast.Wind wind,SingleForecast.Fallout fallout)
        {
            forecasts = new List<SingleForecast>();
            forecasts.Add(new SingleForecast(temp, press, wind, fallout));
        }
        public void AddNewForecast(double temp, short press, SingleForecast.Wind wind, SingleForecast.Fallout fallout)
        {
            forecasts.Add(new SingleForecast(temp, press, wind, fallout));
        }

        public void AddForecastFromConsole()
        {
            Console.WriteLine("Please enter temperature");
            int temp = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter pressure");
            short pres = short.Parse(Console.ReadLine());
            Console.WriteLine("Please enter fallout type(0 - no fallout, 1 - rain, 2 - snow)");
            SingleForecast.Fallout fallout = (SingleForecast.Fallout)int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter wind strength(4- strong, 3 - mild, 2 - light, 1 - no wind)");
            SingleForecast.Wind wind = (SingleForecast.Wind)int.Parse(Console.ReadLine());
            AddNewForecast(temp, pres, wind, fallout);
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Weather forecast for the next {forecasts.Count} days.\n");
            builder.Append("Temp(C)     Pressure      Wind      Fallout\n");
            foreach (SingleForecast forc in forecasts)
            {
                builder.Append($"{forc.Temperature}         {forc.Pressure}        {forc.Windiness}       {forc.FalloutType}\n");
            }
            builder.Append("________________________________________________________________");
            return builder.ToString();
        }

    }
}
