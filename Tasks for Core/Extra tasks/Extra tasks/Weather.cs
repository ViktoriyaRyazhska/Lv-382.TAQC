using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks
{
    class Weather
    {
        List<WeatherForDay> WeatherForecasts = new List<WeatherForDay>();
        public Weather()
        {

        }
        public Weather(params WeatherForDay[] a)
        {
            foreach (var n in a)
            {
                WeatherForecasts.Add(n);
            }
        }
        public void PrintAll()
        {
            Console.WriteLine("\tтемпература" + "\tатм.тиск" + "\tсила вiтру" + "\tопади");
            foreach (var n in WeatherForecasts)
            {
                Console.WriteLine(n.ToString());
            }
        }
    }

    class WeatherForDay
    {
        private int Temperature { get; set; }
        private int Atmosphere { get; set; }
        private WinterPower Winter { get; set; }
        private Rain RainForDay { get; set; }
        public WeatherForDay() { }
        public WeatherForDay(int Temperature, int Atmosphere, string Winter, string RainForDay)
        {
            this.Temperature = Temperature;
            this.Atmosphere = Atmosphere;
            this.Winter = new WinterPower(Winter);
            this.RainForDay = new Rain(RainForDay);
        }
        public void Input(string n)
        {
            string[] inputArr = n.Split(',');
            Temperature = int.Parse(inputArr[0]);
            Atmosphere = int.Parse(inputArr[1]);
            Winter = new WinterPower(inputArr[2]);
            RainForDay = new Rain(inputArr[3]);
        }
        public string Output()
        {
            return this.ToString();
        }
        public override string ToString()
        {
            return "\t" + Temperature + "C" + "\t\t" + Atmosphere + "\t\t" + Winter.value + "\t" + RainForDay.value;
        }

    }
    class WinterPower
    {
        public string key { get; set; }
        public string value { get; set; }
        public WinterPower()
        {

        }
        public WinterPower(string key)
        {
            this.key = key;
            switch (key)
            {
                case "t":
                    value = "тихо";
                    break;
                case "l":
                    value = "легенький";
                    break;
                case "p":
                    value = "помiрний";
                    break;
                case "s":
                    value = "сильний";
                    break;
                default:
                    Console.WriteLine("Invalid value");
                    break;
            }
        }
        public override string ToString()
        {
            return this.value;
        }
    }
    class Rain : WinterPower
    {
        public Rain(string key)
        {
            this.key = key;
            switch (key)
            {
                case "0":
                    value = "без опадів";
                    break;
                case "1":
                    value = "дощ";
                    break;
                case "2":
                    value = "снiг";
                    break;
                default:
                    Console.WriteLine("Invalid value");
                    break;
            }
        }
    }
}
