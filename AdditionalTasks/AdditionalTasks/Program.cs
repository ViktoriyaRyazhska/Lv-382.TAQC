using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("_______________Task1_____________");
            //Car tesla = new Car("Tesla", 250);
            //Car[] garage = new Car[10];
            //for (int i = 0; i < 10; i++)
            //{
            //    garage[i] = (Car)tesla.Clone();
            //    Console.WriteLine($"Car number {i + 1} equals to original - {garage[i].Equals(tesla)}");
            //}
            //Console.WriteLine("_______________Task2_____________");
            //ConsoleManager cman = new ConsoleManager();
            //Car consoleCar = new Car(cman.Input());
            //Console.WriteLine(cman.Output(consoleCar));

            //FileManager fman = new FileManager();
            //Car fileCar = new Car(fman.Input());
            //Console.WriteLine(fman.Output(fileCar));
            //Console.WriteLine("_______________Task(Generics1)_____________");
            //GenericsTaskMethods.InsertIntoSortedList();
            //Console.WriteLine("_______________Task(Generics2)_____________");
            //GenericsTaskMethods.Add2SortedLists();
            //Console.WriteLine("_______________Task(Generics3)_____________");
            ////Failed  //GenericsTaskMethods.ManuallySort();
            //Console.WriteLine("_______________Task(Generics4)_____________");
            //GenericsTaskMethods.CountDistinctSymbols();
            //Console.WriteLine("_______________Task(Generics6)_____________");
            //GenericsTaskMethods.SymbolsBetweenColons();
            //Console.WriteLine("_______________Task(Generics7)_____________");
            //GenericsTaskMethods.IsItSorted();
            WeatherForecast WForecast = new WeatherForecast();
            for (int i = 0; i < 3; i++)
            {
                WForecast.AddForecastFromConsole();
            }
            Console.WriteLine(WForecast.ToString());
            
        }
    }
}
