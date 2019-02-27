using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Forecast[] forecast = new Forecast[12];
            forecast[0] = new Forecast(2, 755, WindStrength.l, Precipitation.Rain);
            forecast[1] = new Forecast(-4, 500, WindStrength.p, Precipitation.Snow);
            forecast[2] = new Forecast(0, 310, WindStrength.s, Precipitation.NoPresipitation);
            forecast[3] = new Forecast(13, 200, WindStrength.t, Precipitation.Rain);
            forecast[4] = new Forecast(6, 800, WindStrength.p, Precipitation.Rain);
            forecast[5] = new Forecast(2, 100, WindStrength.t, Precipitation.Snow);
            forecast[6] = new Forecast(-10, 900, WindStrength.p, Precipitation.Snow);
            forecast[7] = new Forecast(-2, 765, WindStrength.t, Precipitation.Rain);
            forecast[8] = new Forecast(0, 500, WindStrength.s, Precipitation.NoPresipitation);
            forecast[9] = new Forecast(0, 517, WindStrength.p, Precipitation.NoPresipitation);
            forecast[10] = new Forecast(1, 490, WindStrength.p, Precipitation.Rain);
            forecast[11] = new Forecast(3, 267, WindStrength.l, Precipitation.NoPresipitation);


            Console.WriteLine("Temperature \t Pressure \t Wind Strength \t Precipitation");
            foreach(Forecast f in forecast)
            {
                f.Print();
            }
        }
    }
}
