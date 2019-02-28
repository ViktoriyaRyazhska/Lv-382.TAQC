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
        public void AddMultipleForecasts(SingleForecast[] arrayForecast)
        {
            forecasts.AddRange(arrayForecast);
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

        public void ForecastsSortedByTemperatureDesc()
        {
            var Sorting = from cast in forecasts
                          orderby cast.Temperature descending
                          select cast;
            StringBuilder builder = new StringBuilder();
            builder.Append($"Weather forecast for the next {forecasts.Count} days sorted by temperature.\n");
            builder.Append("Temp(C)     Pressure      Wind      Fallout\n");
            foreach (SingleForecast forc in Sorting)
            {
                builder.Append($"{forc.Temperature}         {forc.Pressure}        {forc.Windiness}       {forc.FalloutType}\n");
            }
            builder.Append("________________________________________________________________");
            Console.WriteLine(builder.ToString());
        }
        public double AvgTemperatureWhenNoWind()
        {
            var Sorting = from cast in forecasts
                          where cast.Windiness==SingleForecast.Wind.NoWind
                          select cast;
            return Sorting.Average(x => x.Temperature);
        }
        public int[] CountDaysWithDiffFallout()
        {
            int[] res = new int[2];
            res[0] = forecasts.Select(x => x.FalloutType == SingleForecast.Fallout.NoFallout).Count();
            res[1] = forecasts.Select(x => x.FalloutType == SingleForecast.Fallout.Rain|| x.FalloutType == SingleForecast.Fallout.Snow).Count();
            return res;
        }
        public void DaysWhenPressureLowerThan(short pressure)
        {
            var Sorting = from cast in forecasts
                          where cast.Pressure < pressure
                          select cast;
            StringBuilder builder = new StringBuilder();
            builder.Append($"Weather forecast for the next {forecasts.Count} days when pressure is lower than {pressure}.\n");
            builder.Append("Temp(C)     Pressure      Wind      Fallout\n");
            foreach (SingleForecast forc in Sorting)
            {
                builder.Append($"{forc.Temperature}         {forc.Pressure}        {forc.Windiness}       {forc.FalloutType}\n");
            }
            builder.Append("________________________________________________________________");
            Console.WriteLine(builder.ToString());
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
        public override bool Equals(object obj)
        {
            bool equal = true;
            if (obj is WeatherForecast)
            {
                WeatherForecast temp = (WeatherForecast)obj;
                for (int i = 0; i < this.forecasts.Count; i++)
                {
                    if (this.forecasts[i].FalloutType != temp.forecasts[i].FalloutType ||
                        this.forecasts[i].Windiness != temp.forecasts[i].Windiness ||
                            this.forecasts[i].Pressure != temp.forecasts[i].Pressure ||
                        this.forecasts[i].Temperature != temp.forecasts[i].Temperature)
                    {
                        equal = false;
                    }
                }
                return equal;
            }
            else
            {
                return false;
            }
        }

    }
}
