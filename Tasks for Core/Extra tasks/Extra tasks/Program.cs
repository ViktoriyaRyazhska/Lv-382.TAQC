using Extra_tasks.Interfaces;
using System;
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


            //Doctor d1 = new Doctor();
            ////d1.Age = 33;
            ////d1.Name = "Bob";
            //Doctor d2 = (Doctor)d1.Clone();
            //Doctor d3 = (Doctor)d1.Clone();
            //Doctor d4 = (Doctor)d1.Clone();
            //Doctor d5 = (Doctor)d1.Clone();
            //Doctor d6 = (Doctor)d1.Clone();
            //Doctor d7 = (Doctor)d1.Clone();
            //Doctor d8 = (Doctor)d1.Clone();
            //Doctor d9 = (Doctor)d1.Clone();
            //Doctor d10 = (Doctor)d1.Clone();
            ////d2.Age = 35;
            ////d2.Name = "Joe";

            ConsoleManager cm = new ConsoleManager();
            cm.Input();
            cm.Output("gmdg"+cm.inp);
            FileManager fm = new FileManager();

            //FileManager f1 = new FileManager();
            //f1.Output(d1.Age);
            //f1.Output(d1.Name);
            //f1.Output(d2.Age);
            //f1.Output(d2.Name);
            //f1.Output(d10.Age);
            //f1.Output(d10.Name);
            Console.ReadKey();


            //Array1.Century();
            //Console.ReadKey();

            //Array2.Row(20);
            //Console.ReadKey();

            //Array3.Sum30(11);
            //Console.ReadKey();

            //Array4.Row2();
            //Console.ReadKey();

            //Array5.TriangleType();
            //Console.ReadKey();

            //Array6.NotEqualNumber();
            //Console.ReadKey();

            //Array7.NumberK(8);
            //Console.ReadKey();

            //Array8.TopSameD(2600, 1300);
            //Console.ReadKey();

            //Array9.SumCos(40); //need fixing
            //Console.ReadKey();

            //Array10.S(40); //need fixing
            //Console.ReadKey();

            //Array11.TMax(); 
            //Console.ReadKey();

            //Array12.AverageMark();
            //Console.ReadKey();

            //Array13.NatNumber();
            //Console.ReadKey();

            //Array14.CountUnicSymbols();
            //Console.ReadKey();

            //Array15.Sum2LovestElements();
            //Console.ReadKey();

            //Array16.Index();
            //Console.ReadKey();


            //Weather weater = new Weather(new WeatherForDay(-2, 751, "p", "2"), new WeatherForDay(3, 743, "l", "2")); //1
            //weater.PrintAll();
            //Console.ReadKey();
        }
    }
}
