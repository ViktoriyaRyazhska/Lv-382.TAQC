using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast
{
    class Compar : IComparer<Forecast>
    {
        public int Compare(Forecast f1, Forecast f2)
        {
            if (f1.Temperature > f2.Temperature) return 1;
            else return 0;
        }
    }
    class Forecast
    {
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public Wind windsType { get; set; }
        public Fallout falloutType { get; set; }
        public enum Wind
        {
            None = 1,
            Light = 2,
            Middle = 3,
            Strong = 4
        };
        public enum Fallout
        {
            NoFallout = 0,
            Rain = 1,
            Snow = 2
        };
        public Forecast()
        {

        }
        public Forecast(double temperature, double pressure, Wind wind, Fallout fallout)
        {
            this.Temperature = temperature;
            this.Pressure = pressure;
            this.windsType = wind;
            this.falloutType = fallout;

        }

        public override string ToString()
        {
            return $"Temperature: {Temperature}, Pressure: {Pressure}, Wind: {windsType}, Fallout: {falloutType}";
        }

        public override bool Equals(object obj)
        {
            Forecast forecast = obj as Forecast;
            return Temperature == forecast.Temperature && Pressure == forecast.Pressure &&
                windsType == forecast.windsType && falloutType == forecast.falloutType;
        }

        public static bool operator ==(Forecast f1, Forecast f2)
        {
            return f1.Equals(f2);
        }

        public static bool operator !=(Forecast f1, Forecast f2)
        {
            return !f1.Equals(f2);
        }
        public void Read()
        {
            double temperature;
            double pressure;
            Wind wind;
            Fallout fallout;
            Console.WriteLine("Input temperature:");
            temperature = double.Parse(Console.ReadLine());
            Console.WriteLine("Input pressure:");
            pressure = double.Parse(Console.ReadLine());
            Console.WriteLine("Input wind:");
            wind = (Wind)Enum.Parse(typeof(Wind), Console.ReadLine());
            Console.WriteLine("Input fallout:");
            fallout = (Fallout)Enum.Parse(typeof(Fallout), Console.ReadLine());
            Temperature = temperature;
            Pressure = pressure;
            windsType = wind;
            falloutType = fallout;
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public object Clone()
        {
            return new Forecast(Temperature, Pressure, windsType, falloutType);
        }



        public void Start()
        {
            int days = 12;
            List<Forecast> forecasts = new List<Forecast>();
            Forecast forecast;

            Random random = new Random();
            Wind[] winds = (Wind[])Enum.GetValues(typeof(Wind));
            Fallout[] fallouts = (Fallout[])Enum.GetValues(typeof(Fallout));
            for (int i = 0; i < days; i++)
            {
                forecast = new Forecast();
                forecast.Temperature = random.Next(-15, 35);
                forecast.Pressure = random.Next(550, 750);
                forecast.windsType = winds[random.Next(0, 4)];
                forecast.falloutType = fallouts[random.Next(0, 3)];

                forecasts.Add(forecast);
            }
            forecasts.Sort(new Compar());
            foreach (var f in forecasts)
            {
                f.Print();
            }
            Console.WriteLine("Input pressure limit = ");
            double pressLimit = double.Parse(Console.ReadLine());
            Console.WriteLine($"Days with pressure < {pressLimit}");
            foreach (var f in forecasts)
            {
                if (pressLimit < f.Pressure)
                {
                    f.Print();
                }
            }
            int noWind = 0;
            double temp = 0;
            foreach (var f in forecasts)
            {
                if (f.windsType == Wind.None)
                {
                    noWind++;
                    temp += f.Temperature;
                }
            }
            Console.WriteLine($"Average value of the temperature of days without wind: {temp / noWind}");


        }
    }
}
