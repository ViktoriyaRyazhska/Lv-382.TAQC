using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level8
{
    class Questions
    {
        public static string AreYouPlayingBanjo(string name)
        {
            if (name[0] == 'r' || name[0] == 'R')
            {
                return name + " plays banjo";
            }
            return name + " does not play banjo";
        }
    }

   


[TestFixture]
    public class AreYouPlayingBanjo
    {
        [Test]
        public static void Martin()
        {
            Assert.AreEqual("Martin does not play banjo", Questions.AreYouPlayingBanjo("Martin"));
        }

        [Test]
        public static void Rikke()
        {
            Assert.AreEqual("Rikke plays banjo", Questions.AreYouPlayingBanjo("Rikke"));
        }
    }

}
