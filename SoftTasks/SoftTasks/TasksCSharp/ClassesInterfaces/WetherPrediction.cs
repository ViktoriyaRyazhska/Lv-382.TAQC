using SoftTasks.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.ClassesInterfaces
{
    class WetherPrediction : ICloneable
    {
        public decimal Temperature { get; set; }
        public decimal Pressure { get; set; }
        public Wind CurrentWind { get; set; }
        public Precipitation Precipitations { get; set; }

        public WetherPrediction()
        {

        }

        public WetherPrediction(decimal Temperature, decimal Pressure,
            Wind Winds, Precipitation Precipitations)
        {
            this.Temperature = Temperature;
            this.Temperature = Temperature;
            CurrentWind = Winds;
            this.Precipitations = Precipitations;
        }

        public override string ToString()
        {
            return $"Temperature: {Temperature}, Pressure: {Pressure}," +
                    $"Wind: {CurrentWind}, Precipitation: {Precipitations}";
        }

        public override bool Equals(object obj)
        {
            WetherPrediction wp = obj as WetherPrediction;

            if (wp == null) return false;

            return Temperature == wp.Temperature && Pressure == wp.Pressure &&
                CurrentWind == wp.CurrentWind && Precipitations == wp.Precipitations;
        }

        public static bool operator ==(WetherPrediction wp1, WetherPrediction wp2)
        {
            return wp1.Equals(wp2);
        }

        public static bool operator !=(WetherPrediction wp1, WetherPrediction wp2)
        {
            return !wp1.Equals(wp2);
        }

        public void PrintToConsole()
        {
            Console.WriteLine(ToString());
        }

        public void ReadFromConsole()
        {
            decimal temperature;
            decimal pressure;
            Wind wind;
            Precipitation precipitations;

            Console.WriteLine("Input temperature:");
            if (!InputOutput.TryLoop(inp => decimal.Parse(inp), out temperature)) return;
            Console.WriteLine("Input pressure:");
            if (!InputOutput.TryLoop(inp => decimal.Parse(inp), out pressure)) return;
            Console.WriteLine("Input wind:");
            if (!InputOutput.TryLoop(inp => (Wind)Enum.Parse(typeof(Wind), inp), out wind)) return;
            Console.WriteLine("Input precipitation:");
            if (!InputOutput.TryLoop(inp => (Precipitation)Enum.Parse(typeof(Precipitation), inp), out precipitations)) return;

            Temperature = temperature;
            Pressure = pressure;
            CurrentWind = wind;
            Precipitations = precipitations;
        }


        public object Clone()
        {
            return new WetherPrediction(Temperature, Pressure, CurrentWind, Precipitations);
        }


        //Runns the app
        //Tasks A. B. C, D
        public void Run()
        {
            int days = 12;
            List<WetherPrediction> whether = new List<WetherPrediction>();
            WetherPrediction dayWether;

            Random r = new Random();
            Wind[] valuesWind = (Wind[])Enum.GetValues(typeof(Wind));
            Precipitation[] valuesPrecipitation = (Precipitation[])Enum.GetValues(typeof(Precipitation));

            //Generating random input
            for (int i = 0; i < days; i++)
            {
                dayWether = new WetherPrediction();
                dayWether.Temperature = r.Next(-10, 30);
                dayWether.Pressure = r.Next(500, 750);
                dayWether.CurrentWind = valuesWind[r.Next(0, 4)];
                dayWether.Precipitations = valuesPrecipitation[r.Next(0, 3)];

                whether.Add(dayWether);
            }

            whether.Sort(new Compr());

            Console.WriteLine($"Temperature     Pressure     " +
                    $"Wind      Precipitation");

            foreach (var wp in whether)
            {
                wp.PrintToConsole();
            }

            decimal pressureLimit, avgTempNoWind = 0;
            int avgTempNoWindCount = 0;
            InputOutput.TryLoop(inp => int.Parse(inp), out pressureLimit);

            int NoPreccipCount = 0, SnowCount = 0, rainCount = 0;

            Console.WriteLine($"Days with pressure < {pressureLimit}");
            foreach (var wp in whether)
            {
                if (wp.CurrentWind == Wind.None)
                {
                    avgTempNoWindCount++;
                    avgTempNoWind += wp.Temperature;
                }
                if (pressureLimit < wp.Pressure)
                {
                    wp.PrintToConsole();
                }

                if (wp.Precipitations == Precipitation.None) NoPreccipCount++;
                else if (wp.Precipitations == Precipitation.Rain) rainCount++;
                else SnowCount++;
            }

            Console.WriteLine($"No wind avg temp: {avgTempNoWind / avgTempNoWindCount}");
            Console.WriteLine($"Days with Good wether: {NoPreccipCount}, Rain: {rainCount}, Snow: {SnowCount}");
        }

        class Compr : IComparer<WetherPrediction>
        {
            public int Compare(WetherPrediction wp1, WetherPrediction wp2)
            {
                if (wp1.Temperature > wp2.Temperature) return 1;
                else if (wp1.Temperature < wp2.Temperature) return -1;
                else return 0;
            }
        }


    }

    enum Wind
    {
        None,
        Light,
        Medium,
        Strong
    }

    enum Precipitation
    {
        None,
        Rain,
        Snow
    }
}
