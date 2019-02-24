using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level8
{
    class Calculator
    {
        public static double basicOp(char operation, double value1, double value2)
        {
            if (operation == '+')
                return value1 + value2;
            if (operation == '-')
                return value1 - value2;
            if (operation == '/')
                return value1 / value2;
            if (operation == '*')
                return value1 * value2;
            throw new ArgumentException($"{operation} is not a valid operation");

        }
    }
   

        [TestFixture]
        public class TestCalculator
    {
            [Test]
            public void StaticTests()
            {
                Assert.AreEqual(Calculator.basicOp('+', 4, 7), 11);
                Assert.AreEqual(Calculator.basicOp('-', 15, 18), -3);
                Assert.AreEqual(Calculator.basicOp('*', 5, 5), 25);
                Assert.AreEqual(Calculator.basicOp('/', 49, 7), 7);
            }
        }
    }

