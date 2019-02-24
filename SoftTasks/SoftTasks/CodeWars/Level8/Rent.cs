using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level8
{
    //Every day you rent the car costs $40. If you rent the car for 7 or more days,
    //    you get $50 off your total. Alternatively, 
    //    if you rent the car for 3 or more days, you get $20 off your total.





    class Rent
    {
        public static int RentCost(int d)
        {
            int cost = 40;
            if (d >= 1 && d <3)
                return cost * d;
            else if (d >= 3 && d < 7)
                return (cost * d) - 20;
            else
                return (cost * d) - 50;
        }
    }
 


[TestFixture]
    public static class RentTests
    {

        private static void testing(int actual, int expected)
        {
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void test1()
        {
            testing(Rent.RentCost(1), 40);
            testing(Rent.RentCost(3), 100);
            testing(Rent.RentCost(7), 230);
        }
    }


}
