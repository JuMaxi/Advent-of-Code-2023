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
    }
}
