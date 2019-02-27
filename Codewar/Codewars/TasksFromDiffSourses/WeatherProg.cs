using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars
{
    class WeaterForecast
    {
        public List<WeatherForDay> WeatherForecasts = new List<WeatherForDay>();
        public WeaterForecast()
        {

        }
        public WeaterForecast(params WeatherForDay[] a)
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
                Console.WriteLine(n.Output());
            }
        }
        public void PrintAllByTemperature()
        {
            Console.WriteLine("\tтемпература" + "\tатм.тиск" + "\tсила вiтру" + "\tопади");
            foreach (var n in WeatherForecasts.OrderByDescending(x => x.Temperature))
            {
                Console.WriteLine(n.ToString());
            }
        }
        public void PrintMidleTemperature()
        {
            Console.Write("\nСередня температура: ");
            List<WeatherForDay> lst = WeatherForecasts.Where(x => x.Winter.Equals("t")).ToList();
            Console.Write(lst.Count != 0 ? lst.Average(x => x.Temperature).ToString() : 0.ToString());
        }
        public void Input(string str)
        {
            WeatherForDay temp = new WeatherForDay();
            temp.Input(str);
            WeatherForecasts.Add(temp);
        }
        public void PrintRainStat()
        {
            Console.WriteLine("Статистика опадoiв: ");
            Console.WriteLine("Днiв без опадiв: " + WeatherForecasts.Where(x => x.RainForDay.key == "0").Count());
            Console.WriteLine("Днiв з опадами: "+ WeatherForecasts.Where(x => x.RainForDay.key == "1").Count());
            Console.WriteLine("Днiв з снiгом: "+ WeatherForecasts.Where(x => x.RainForDay.key == "2").Count());
        }
        public void PrintPreasureDays(int compareValue)
        {
            Console.WriteLine("\tтемпература" + "\tатм.тиск" + "\tсила вiтру" + "\tопади");
            foreach (var n in WeatherForecasts.Where(x => x.Atmosphere < compareValue))
            {
                Console.WriteLine(n.ToString());
            }

        }
    }

    class WeatherForDay
    {
        public int Temperature { get; private set; }
        public int Atmosphere { get; private set; }
        public WinterPower Winter { get; private set; }
        public Rain RainForDay { get; private set; }
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
        public override bool Equals(object obj)
        {
            return this.key.Equals(obj);
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
