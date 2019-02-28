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
            //Console.WriteLine("_______________Task(Generics4)_____________");
            //GenericsTaskMethods.CountDistinctSymbols();
            //Console.WriteLine("_______________Task(Generics6)_____________");
            //GenericsTaskMethods.SymbolsBetweenColons();
            //Console.WriteLine("_______________Task(Generics7)_____________");
            //GenericsTaskMethods.IsItSorted();
            Console.WriteLine("_______________Task Weather Forecast_____________");
            SingleForecast[] forecasts = new SingleForecast[5]
            { 
                new SingleForecast() { Temperature = 12, Pressure = 750, FalloutType = SingleForecast.Fallout.NoFallout, Windiness = SingleForecast.Wind.Mild },
                new SingleForecast() { Temperature = 14, Pressure = 760, FalloutType = SingleForecast.Fallout.Rain, Windiness = SingleForecast.Wind.NoWind },
                new SingleForecast() { Temperature = -24, Pressure = 723, FalloutType = SingleForecast.Fallout.Snow, Windiness = SingleForecast.Wind.Strong },
                new SingleForecast() { Temperature = 40, Pressure = 770, FalloutType = SingleForecast.Fallout.NoFallout, Windiness = SingleForecast.Wind.NoWind },
                new SingleForecast() { Temperature = 27, Pressure = 746, FalloutType = SingleForecast.Fallout.NoFallout, Windiness = SingleForecast.Wind.Light }
            };
            WeatherForecast WForecast = new WeatherForecast();
            WForecast.AddMultipleForecasts(forecasts);
            for (int i = 0; i < 1; i++)
            {
                WForecast.AddForecastFromConsole();
            }
            Console.WriteLine(WForecast.ToString());
            WForecast.ForecastsSortedByTemperatureDesc();
            
        }
    }
}
