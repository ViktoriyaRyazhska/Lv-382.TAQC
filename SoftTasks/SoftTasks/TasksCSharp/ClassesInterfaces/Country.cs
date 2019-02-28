using SoftTasks.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.TasksCSharp.ClassesInterfaces
{
    class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Area { get; set; }
        public int Population { get; set; }

        public string Continent { get; set; }


        public Country()
        {

        }

        public Country(int ID, string Name,
            int Area, int Population, string Continent)
        {
            this.ID = ID;
            this.Name = Name;
            this.Area = Area;
            this.Population = Population;
            this.Continent = Continent;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}," +
                    $"Area: {Area}, Population: {Population}, Population: {Continent}";
        }

        public override bool Equals(object obj)
        {
            Country cntry = obj as Country;

            if (cntry == null) return false;

            return ID == cntry.ID && Name == cntry.Name &&
                Area == cntry.Area && Population == cntry.Population && Continent == cntry.Continent;
        }

        public static bool operator ==(Country wp1, Country wp2)
        {
            return wp1.Equals(wp2);
        }

        public static bool operator !=(Country wp1, Country wp2)
        {
            return !wp1.Equals(wp2);
        }

        public void PrintToConsole()
        {
            Console.WriteLine(ToString());
        }

        public void ReadFromConsole()
        {
            int ID;
            string name;
            int area;
            int population;
            string continent;

            Console.WriteLine("Input ID:");
            if (!InputOutput.TryLoop(inp => int.Parse(inp), out ID)) return;
            Console.WriteLine("Input Name:");
            if (!InputOutput.TryLoop(inp => inp, out name)) return;
            Console.WriteLine("Input area:");
            if (!InputOutput.TryLoop(inp => int.Parse(inp), out area)) return;
            Console.WriteLine("Input population:");
            if (!InputOutput.TryLoop(inp => int.Parse(inp), out population)) return;
            Console.WriteLine("Input Continent:");
            if (!InputOutput.TryLoop(inp => inp, out continent)) return;

            this.ID = ID;
            Name = name;
            Area = area;
            Population = population;
            Continent = continent;
        }


        //Runns the app
        //Tasks A. B. C, D
        public void Run()
        {
            int days = 12;
            List<Country> countries = new List<Country>();
            Country country;

            Random r = new Random();

            List<string> continents = new List<string>();
            continents.Add("Europe");
            continents.Add("America");
            continents.Add("Afric");

            //Generating random input
            for (int i = 0; i < days; i++)
            {
                country = new Country();
                country.ID = i + 1;
                country.Name = "Country " + i;
                country.Area = r.Next(10000, 1000000);
                country.Population = r.Next(1000, 2000000);
                country.Continent = continents[r.Next(0, continents.Count)];

                countries.Add(country);
            }

            countries.Sort(new Compr());

            Console.WriteLine($"ID      Name      " +
                    $"Area     Population       Continent");

            foreach (var ct in countries)
            {
                ct.PrintToConsole();
            }

            int europePopul=0, maxPopulation = 0;
            Country maxPopulationCntry= countries[0];

            Dictionary<string, int> continentsArea = new Dictionary<string, int>();
            continentsArea.Add("Europe",0);
            continentsArea.Add("America",0);
            continentsArea.Add("Afric",0);

            foreach (var ct in countries)
            {
                continentsArea[ct.Continent] += ct.Area;
                if (ct.Continent == "Europe")
                {
                    europePopul+=ct.Population;

                }
                if (maxPopulationCntry.Population < ct.Population)
                {
                    maxPopulationCntry = ct;
                }
            }

            Console.WriteLine($"Europe total population: {europePopul}");

            Console.WriteLine("Continent     Population");
            foreach (var keyValue in continentsArea)
            {
                Console.WriteLine($"{keyValue.Key}    {keyValue.Value}");
            }

            Console.WriteLine($" {maxPopulationCntry.Name} has  biggest population: {maxPopulationCntry.Population}");
        }
    }



    class Compr : IComparer<Country>
    {
        public int Compare(Country ct1, Country ct2)
        {
            if (ct1.ID > ct2.ID) return 1;
            else if (ct1.ID < ct2.ID) return -1;
            else return 0;
        }
    }
}
