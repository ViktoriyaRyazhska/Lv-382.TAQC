using System;
using System.Collections.Generic;

namespace Codewars
{
    class CountryStatisticDashboard
    {
        List<CountryStatistic> CountryStatistics = new List<CountryStatistic>();
        public CountryStatisticDashboard()
        {

        }
        public CountryStatisticDashboard(params CountryStatistic[] New)
        {
            foreach (var n in New)
            {
                CountryStatistics.Add(n);
            }
        }
        public void OutputAll()
        {
            Console.WriteLine("\tкраiна" + "\tплоща" + "\tкiльк.нас." + "\tматерик");
            foreach (var n in CountryStatistics)
            {
                Console.WriteLine(n.ToString());
            }
        }
    }



    class CountryStatistic
    {
        public int id { get; private set; }
        public int arrea { get; private set; }

        public int peopleCount { get; private set; }

        public string continent { get; private set; }
        public CountryStatistic()
        {

        }
        public CountryStatistic(int id, int arrea, int people, string continent)
        {
            this.id = id;
            this.arrea = arrea;
            this.peopleCount = people;
            this.continent = continent;
        }
        public void Input(int id, int arrea, int people, string continent)
        {
            this.id = id;
            this.arrea = arrea;
            this.peopleCount = people;
            this.continent = continent;
        }
        public void Output()
        {
            Console.WriteLine("\t" + id + "C" + "\t\t" + arrea + "\t\t" + peopleCount + "\t" + continent);
        }
        public override string ToString()
        {
            return "\t" + id + "\t" + arrea + "\t" + peopleCount + "\t\t" + continent;
        }
        public override bool Equals(object obj)
        {
            if (obj is CountryStatistic && obj != null)
            {
                CountryStatistic a = (CountryStatistic)obj;
                return (this.id == a.id && this.arrea == a.arrea && this.peopleCount == a.peopleCount && this.continent == a.continent);
            }
            else
            {
                return false;
            }
        }
    }

}

