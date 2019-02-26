using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level6
{
    class TribonacciSequence
    {
        public double[] Tribonacci(double[] signature, int n)
        {
            if (n <= signature.Length) return signature.Take(n).ToArray();

            double[] result = new double[n];
            Array.Copy(signature, result, signature.Length);
            result[signature.Length] = signature.Sum();


            for (int i= signature.Length+1; i < n; i++)
            {
                result[i] = result[i - 1] * 2 - result[i - signature.Length - 1];
            }
            return result;
        }
    }

   
[TestFixture]
    public class XbonacciTest
    {
        private TribonacciSequence variabonacci;

        [SetUp]
        public void SetUp()
        {
            variabonacci = new TribonacciSequence();
        }

        [TearDown]
        public void TearDown()
        {
            variabonacci = null;
        }

        [Test]
        public void Tests()
        {
            Assert.AreEqual(new double[] { 1, 1, 1, 3, 5, 9, 17, 31, 57, 105 }, variabonacci.Tribonacci(new double[] { 1, 1, 1 }, 10));
            Assert.AreEqual(new double[] { 0, 0, 1, 1, 2, 4, 7, 13, 24, 44 }, variabonacci.Tribonacci(new double[] { 0, 0, 1 }, 10));
            Assert.AreEqual(new double[] { 0, 1, 1, 2, 4, 7, 13, 24, 44, 81 }, variabonacci.Tribonacci(new double[] { 0, 1, 1 }, 10));
        }
    }
}
