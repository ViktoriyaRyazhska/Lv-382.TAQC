using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level6
{
    class HelpTheBookseller
    {
        public static string stockSummary(String[] lstOfArt, String[] lstOf1stLetter)
        {
            if (lstOfArt.Length == 0 || lstOf1stLetter.Length == 0) return string.Empty;
            Dictionary<char, int> count = new Dictionary<char, int>();
            char caterory;
            StringBuilder result = new StringBuilder();

            foreach (string category in lstOf1stLetter)
            {
                count.Add(category[0], 0);
            }

            for (int i = 0; i < lstOfArt.Length; i++)
            {
                caterory = lstOfArt[i][0];
                if (count.ContainsKey(caterory))
                {
                    count[caterory] += int.Parse(lstOfArt[i].Split(' ')[1]);
                }
            }
            foreach (var item in count)
            {
                result.Append($"({item.Key} : {item.Value}) - ");
            }
            result.Remove(result.Length - 3,3);
            return result.ToString();
        }
    }

[TestFixture]
    public class StockListTests
    {

        [Test]
        public void Test1()
        {
            string[] art = new string[] { "ABAR 200", "CDXE 500", "BKWR 250", "BTSQ 890", "DRTY 600" };
            String[] cd = new String[] { "A", "B" };
            Assert.AreEqual("(A : 200) - (B : 1140)", HelpTheBookseller.stockSummary(art, cd));
        }
    }


}
