﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Weather weater = new Weather(new WeatherForDay(-2, 751, "p", "2"), new WeatherForDay(3, 743, "l", "2"));
            weater.PrintAll();

            Console.ReadKey();
        }
    }
}
