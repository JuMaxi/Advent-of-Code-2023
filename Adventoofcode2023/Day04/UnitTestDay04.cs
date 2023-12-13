using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day04
{
    public class UnitTestDay04
    {
        [Fact]
        public void Test01()
        {
            Part01 part01 = new();

            int sum = part01.SumCards();

            Assert.Equal(13, sum);
        }

        [Fact]
        public void Test02()
        {
            Part02 part02 = new();

            int sum = part02.SumCards();

            Assert.Equal(30, sum);
        }

    }
}
