using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day05
{
    public class UnitTestDay05
    {
        [Fact]
        public void Test01()
        {
            Part01 part01 = new();

            long lowestLocation = part01.GetLowestLocation();

            Assert.Equal(35, lowestLocation);
        }

        [Fact]
        public void Test02()
        {
            Part02 part02 = new();

            long lowestLocation = part02.GetLowestLocation();

            Assert.Equal(46, lowestLocation);
        }
    }
}
