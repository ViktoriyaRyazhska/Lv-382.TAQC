using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalTasks
{

    public class Country
    {
        public enum Continents
        {
            Asia = 1,
            Africa = 2,
            NorthAmerica = 3,
            SouthAmerica = 4,
            Antarctica = 5,
            Europe = 6,
            Australia = 7
        };
        private short CountryID;
        public short countryID
        {
            get { return CountryID; }
            set { CountryID = value; }
        }
        private string Name;
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        private double Area;
        public double area
        {
            get { return Area; }
            set { Area = value; }
        }
        private long Population;
        public long population
        {
            get { return Population; }
            set { Population = value; }
        }
        private Continents Continent;
        public Continents continent
        {
            get { return Continent; }
            set { Continent = value; }
        }
        public Country()
        {
        }
        public Country(short countryID, string name, double area, long population, Continents continent)
        {
            this.countryID = countryID;
            this.name = name;
            this.area = area;
            this.population = population;
            this.continent = continent;
        }
        public override string ToString()
        {
            return $"{countryID.ToString().PadRight(8)}{name.ToString().PadRight(16)}{area.ToString().PadRight(16)}{population.ToString().PadRight(18)}{continent.ToString().PadRight(10)}\n";
        }
        public override bool Equals(object obj)
        {
            if (obj is Country)
            {
                Country temp = (Country)obj;
                if (this.countryID == temp.countryID && this.name == temp.name && this.area == temp.area && this.population == temp.population && this.continent == temp.continent)
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
        public static Country ReadFromConsole()
        {
            Country country = new Country();
            Console.WriteLine("Please enter Country ID:");
            country.countryID = short.Parse(Console.ReadLine());
            Console.WriteLine("Please enter name of the Country:");
            country.name = Console.ReadLine();
            Console.WriteLine("Please enter Country's area:");
            country.area = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter Country's population");
            country.population = long.Parse(Console.ReadLine());
            Console.WriteLine("Please enter Country's continent:\n1 - Asia\n2 - Africa\n3 - North America\n4 - South America\n5 - Antarctica\n6 - Europe\n7 - Australia");
            country.continent = (Continents)(int.Parse(Console.ReadLine()));
            return country;
        }
    }
    public class CountriesList
    {
        private List<Country> Countries = new List<Country>();
        public List<Country> countries
        {
            get { return Countries; }
            set { Countries = value; }
        }

        public CountriesList()
        {
        }

        public CountriesList(short countryID, string name, double area, long population, Country.Continents continent)
        {
            countries = new List<Country>();
            countries.Add(new Country(countryID, name, area, population, continent));
        }

        public void AddCountry(short countryID, string name, double area, long population, Country.Continents continent)
        {
            if (countries.Find(x => x.countryID == countryID) == null)
            {
                countries.Add(new Country(countryID, name, area, population, continent));
            }
            else
            {
                Console.WriteLine($"Country with this ID:{countryID} is already present in list.");
            }
        }

        public void AddCountry(Country country)
        {
            if (countries.Find(x => x.countryID == country.countryID) == null)
            {
                countries.Add(country);
            }
            else
            {
                Console.WriteLine($"Country with this ID:{country.countryID} is already present in list.");
            }
        }

        public void AddMultipleCountries(Country[] inputCountries)
        {
            for (int i = 0; i < inputCountries.Count(); i++)
            {
                if (countries.Find(x => x.countryID == inputCountries[i].countryID) == null)
                {
                    countries.Add(inputCountries[i]);
                }
                else
                {
                    Console.WriteLine($"Country with this ID:{inputCountries[i].countryID} is already present in list.");
                }
            }
        }

        public void AddCountryFromConsole()
        {
            try
            {
                countries.Add(Country.ReadFromConsole());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Incorrect input. " + ex.Message);
            }
        }

        private string printTemplate(IEnumerable<Country> inputCountries)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("ID      Name            Area            Population        Continent\n");
            foreach (Country country in inputCountries)
            {
                builder.Append(country.ToString());
            }
            builder.Append("________________________________________________________________");
            return builder.ToString();
        }

        public void CountriesSortedByIdAsc()
        {
            var Sorting = from cntry in countries
                          orderby cntry.countryID ascending
                          select cntry;
            Console.WriteLine($"Countries sorted by ID's.\n");
            Console.WriteLine(printTemplate(Sorting));
        }

        public long CountEuropePopulation()
        {
            return countries.Where(x => x.continent == Country.Continents.Europe).Sum(x => x.population);
        }

        public double[] CountriesAreaByContinents()
        {
            double[] res = new double[7];
            foreach (Country country in countries)
            {
                res[(int)country.continent - 1] += country.area;
            }
            return res;
        }

        public void CountryWithLargestPopulation()
        {
            Console.WriteLine("Country with the biggest population:");
            Console.WriteLine(printTemplate(countries.Where(x => x.population == countries.Max(y => y.population))));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"List of Countries.\n");
            builder.Append("ID      Name            Area            Population        Continent\n");
            foreach (Country country in countries)
            {
                builder.Append(country.ToString());
            }
            builder.Append("________________________________________________________________");
            return builder.ToString();
        }

        public override bool Equals(object obj)
        {
            bool equal = true;
            if (obj is CountriesList)
            {
                CountriesList temp = (CountriesList)obj;
                for (int i = 0; i < this.countries.Count; i++)
                {
                    if (!this.countries[i].Equals(temp.countries[i]))
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
            CountriesList countries = new CountriesList();
            Country[] list = new Country[]
            {
                new Country(2,"USA",9834000,325700000,Country.Continents.NorthAmerica),
                new Country(1,"Japan",377973,126440000,Country.Continents.Asia),
                new Country(3,"United Kingdom",242492,6202000,Country.Continents.Europe),
                new Country(5,"Germany",357386,82790000,Country.Continents.Europe),
                new Country(6,"Ukraine",603628,44830000,Country.Continents.Europe)
            };
            countries.AddMultipleCountries(list);
            Console.WriteLine(countries.ToString());
            countries.CountriesSortedByIdAsc();
            Console.WriteLine($"Total population of Europe's countries: {countries.CountEuropePopulation()}");
            Console.WriteLine("________________________________________________________________");
            double[] areasContinents = countries.CountriesAreaByContinents();
            Console.WriteLine("Total area of countries of continents:");
            for (int i = 0; i < areasContinents.Length; i++)
            {
                Console.WriteLine($"{(Country.Continents)(i + 1)} - {areasContinents[i]}");
            }
            Console.WriteLine("________________________________________________________________");
            countries.CountryWithLargestPopulation();
        }
    }

}
