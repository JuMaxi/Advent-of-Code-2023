using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day11
{
    public class UnitTestDay11
    {
        [Fact]
        public void Test01()
        {
            Part01 part01 = new();

            int sum = part01.SumShortestPathBetweenGalaxies();

            Assert.Equal(374, sum);
        }
    }
}
