using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesCSharp
{
    class Program
    {
        public static List<Forecast> OrderByTemperatureDescending(List<Forecast> input)
        {
            // return input.OrderByDescending(ob => ob.Temperature).ToList();
            input.Sort((p1, p2) => p1.Temperature.CompareTo(p2.Temperature));
            return input;
        }

        public static int AverageTemperatureWhenNoWind(List<Forecast> input)
        {
            int sum = 0;
            int count = 0;
            foreach (Forecast f in input)
            {
                if (f.WindStrength.DescriptionAttr() == "calm")
                {
                    sum += f.Temperature;
                    count++;
                }
            }

            return sum / count;
        }

        public static void DaysAmountByPrecipitation(List<Forecast> input)
        {
            int daysWithRain = 0;
            int daysWithSnow = 0;
            int daysWithoutPrecipitation = 0;
            foreach (Forecast f in input)
            {
                if (f.Precipitation.DescriptionAttr() == "rain")
                {
                    daysWithRain++;
                }
                if (f.Precipitation.DescriptionAttr() == "snow")
                {
                    daysWithSnow++;
                }
                if (f.Precipitation.DescriptionAttr() == "no precipitation")
                {
                    daysWithoutPrecipitation++;
                }
            }
            Console.WriteLine("Days with rain: " + daysWithRain);
            Console.WriteLine("Days with snow: " + daysWithSnow);
            Console.WriteLine("Days with no precipitation: " + daysWithoutPrecipitation);
        }

        public static List<Forecast> ForecastForDaysWhenPressureBeyond(List<Forecast> input, int pressure)
        {
            List<Forecast> result = new List<Forecast>();

            foreach (Forecast f in input)
            {
                if (f.AtmosphPressure < pressure)
                {
                    result.Add(f);
                }
            }
            return result;
        }



        static void Main(string[] args)
        {
            List<Forecast> forecast = new List<Forecast>
            {
                new Forecast (2, 755, WindStrength.l, Precipitation.Rain),
                new Forecast(-4, 500, WindStrength.p, Precipitation.Snow),
                new Forecast(0, 310, WindStrength.s, Precipitation.NoPresipitation),
                new Forecast(13, 200, WindStrength.t, Precipitation.Rain),
                new Forecast(6, 800, WindStrength.p, Precipitation.Rain),
                new Forecast(2, 100, WindStrength.t, Precipitation.Snow),
                new Forecast(-10, 900, WindStrength.p, Precipitation.Snow),
                new Forecast(-2, 765, WindStrength.t, Precipitation.Rain),
                new Forecast(0, 500, WindStrength.s, Precipitation.NoPresipitation),
                new Forecast(0, 517, WindStrength.p, Precipitation.NoPresipitation),
                new Forecast(1, 490, WindStrength.p, Precipitation.Rain),
                new Forecast(3, 267, WindStrength.l, Precipitation.NoPresipitation)
            };

            //List<Forecast> forecast = new List<Forecast>();
            //forecast.Add(new Forecast(2, 755, WindStrength.l, Precipitation.Rain));

            //for(int i = 0; i< 10; i++)
            //{
            //    forecast.Add((Forecast)forecast[0].Clone());
            //}

            Console.WriteLine("{0, -14}{1, -14}{2, -18}{3, -18}", "Temperature", "Pressure", "Wind Strength", "Precipitation");

            foreach (Forecast f in forecast)
            {
                f.Print();
            }

            Console.WriteLine("\n");

            foreach (Forecast f in OrderByTemperatureDescending(forecast))
            {
                f.Print();
            }

            Console.WriteLine("\nAverage temperature of no wind days: " + AverageTemperatureWhenNoWind(forecast) + "\n");

            DaysAmountByPrecipitation(forecast);

            int pressure = 500;
            Console.WriteLine("\nForecast for days when pressure is beyond " + pressure);
            foreach (Forecast f in ForecastForDaysWhenPressureBeyond(forecast, pressure))
            {
                f.Print();
            }

        }


    }
}
