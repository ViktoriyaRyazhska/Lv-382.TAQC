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
        public SingleForecast(double temp, short press, Wind wind, Fallout fallout)
        {
            this.Temperature = temp;
            this.Pressure = press;
            this.FalloutType = fallout;
            this.Windiness = wind;
        }
        public override string ToString()
        {
            return $"{Temperature.ToString().PadRight(12)}{Pressure.ToString().PadRight(12)}{Windiness.ToString().PadRight(12)}{FalloutType.ToString().PadRight(12)}\n";
        }
        public override bool Equals(object obj)
        {
            if (obj is SingleForecast)
            {
                SingleForecast temp = (SingleForecast)obj;
                if (this.Temperature == temp.Temperature && this.Pressure == temp.Pressure && this.Windiness == temp.Windiness && this.FalloutType == temp.FalloutType)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static SingleForecast ReadFromConsole()
        {
            SingleForecast forecast = new SingleForecast();
            Console.WriteLine("Please enter temperature");
            forecast.Temperature = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter pressure");
            forecast.Pressure = short.Parse(Console.ReadLine());
            Console.WriteLine("Please enter fallout type(0 - no fallout, 1 - rain, 2 - snow)");
            forecast.FalloutType = (SingleForecast.Fallout)int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter wind strength(4 - strong, 3 - mild, 2 - light, 1 - no wind)");
            forecast.Windiness = (SingleForecast.Wind)int.Parse(Console.ReadLine());
            return forecast;
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

        public WeatherForecast(double temp, short press, SingleForecast.Wind wind, SingleForecast.Fallout fallout)
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
            try
            {
                forecasts.Add(SingleForecast.ReadFromConsole());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Incorrect input. " + ex.Message);
            }
        }

        private string printTemplate(IEnumerable<SingleForecast> forecasts)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Temp(C)     Pressure    Wind      Fallout\n");
            foreach (SingleForecast forc in forecasts)
            {
                builder.Append(forc.ToString());
            }
            builder.Append("________________________________________________________________");
            return builder.ToString();
        }

        public void ForecastsSortedByTemperatureDesc()
        {
            var Sorting = from cast in forecasts
                          orderby cast.Temperature descending
                          select cast;
            Console.WriteLine($"Weather forecast for the next {forecasts.Count} days sorted by temperature.\n");
            Console.WriteLine(printTemplate(Sorting));
        }

        public double AvgTemperatureWhenNoWind()
        {
            var Sorting = from cast in forecasts
                          where cast.Windiness == SingleForecast.Wind.NoWind
                          select cast;
            return Sorting.Average(x => x.Temperature);
        }

        public int[] CountDaysWithDiffFallout()
        {
            int[] res = new int[2];
            res[0] = forecasts.Select(x => x.FalloutType == SingleForecast.Fallout.NoFallout).Count();
            res[1] = forecasts.Select(x => x.FalloutType == SingleForecast.Fallout.Rain || x.FalloutType == SingleForecast.Fallout.Snow).Count();
            return res;
        }

        public void DaysWhenPressureLowerThan(short pressure)
        {
            var Sorting = from cast in forecasts
                          where cast.Pressure < pressure
                          select cast;
            Console.WriteLine($"Weather forecast for the next {forecasts.Count} days with pressure lower than {pressure}.\n");
            Console.WriteLine(printTemplate(Sorting));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Weather forecast for the next {forecasts.Count} days.\n");
            builder.Append("Temp(C)     Pressure    Wind      Fallout\n");
            foreach (SingleForecast forc in forecasts)
            {
                builder.Append(forc.ToString());
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
                    if (!this.forecasts[i].Equals(temp.forecasts[i]))
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

        public static void TaskMethod()
        {
            SingleForecast[] forecasts = new SingleForecast[5]
            {
                new SingleForecast() { Temperature = 12, Pressure = 750, FalloutType = SingleForecast.Fallout.NoFallout, Windiness = SingleForecast.Wind.Mild },
                new SingleForecast() { Temperature = 14, Pressure = 760, FalloutType = SingleForecast.Fallout.Rain, Windiness = SingleForecast.Wind.NoWind },
                new SingleForecast() { Temperature = -24, Pressure = 723, FalloutType = SingleForecast.Fallout.Snow, Windiness = SingleForecast.Wind.Strong },
                new SingleForecast() { Temperature = 40, Pressure = 770, FalloutType = SingleForecast.Fallout.NoFallout, Windiness = SingleForecast.Wind.NoWind },
                new SingleForecast() { Temperature = 27, Pressure = 746, FalloutType = SingleForecast.Fallout.NoFallout, Windiness = SingleForecast.Wind.Light }
            };
            WeatherForecast WForecast = new WeatherForecast();
            WForecast.AddMultipleForecasts(forecasts);
            for (int i = 0; i < 1; i++)
            {
                WForecast.AddForecastFromConsole();
            }
            Console.WriteLine(WForecast.ToString());
            WForecast.ForecastsSortedByTemperatureDesc();
            Console.WriteLine("________________________________________________________________");
            Console.WriteLine("Avg temperature when the is no wind will be " + WForecast.AvgTemperatureWhenNoWind());
            Console.WriteLine("________________________________________________________________");
            int[] days = WForecast.CountDaysWithDiffFallout();
            Console.WriteLine($"Num of days with no fallout = {days[0]}, num of days with snow or rain = {days[1]}");
            Console.WriteLine("________________________________________________________________");
            WForecast.DaysWhenPressureLowerThan(750);
        }
    }
}
