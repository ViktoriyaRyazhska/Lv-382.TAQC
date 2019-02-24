using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeWars.Level8
{
    class RemoveSpaces
    {
        public static string NoSpace(string input)
        {
            return input.Replace(" ", string.Empty);
        }
    }



    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void ExampleTests()
        {
            Assert.AreEqual("8j8mBliB8gimjB8B8jlB", RemoveSpaces.NoSpace("8 j 8   mBliB8g  imjB8B8  jl  B"));
            Assert.AreEqual("88Bifk8hB8BB8BBBB888chl8BhBfd", RemoveSpaces.NoSpace("8 8 Bi fk8h B 8 BB8B B B  B888 c hl8 BhB fd"));
            Assert.AreEqual("8aaaaaddddr", RemoveSpaces.NoSpace("8aaaaa dddd r     "));
        }
    }
}
