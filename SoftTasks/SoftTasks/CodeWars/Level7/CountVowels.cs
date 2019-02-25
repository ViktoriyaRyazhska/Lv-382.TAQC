using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level7
{
    class CountVowels
    {
        public static int GetVowelCount(string str)
        {
            int vowelCount = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'a' || str[i] == 'e' || str[i] == 'i' || str[i] == 'o' || str[i] == 'u')
                {
                    vowelCount++;
                }

            }
          

            return vowelCount;
        }
    }



[TestFixture]
    public class KataTests
    {
        [Test]
        public void TestCase1()
        {
            Assert.AreEqual(5, CountVowels.GetVowelCount("abracadabra"), "Nope!");
        }
    }

}
