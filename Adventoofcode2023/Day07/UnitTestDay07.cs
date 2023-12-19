using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day07
{
    public class UnitTestDay07
    {
        [Fact]
        public void Test01()
        {
            Part01 part01 = new();

            long sum = part01.Sum();

            Assert.Equal(6440, sum);
        }

        [Fact] public void Test02()
        {
            Part02 part02 = new();

            long sum = part02.Sum();

            Assert.Equal(5905, sum);
        }
    }
}
