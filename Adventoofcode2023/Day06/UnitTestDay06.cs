using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day06
{
    public class UnitTestDay06
    {
        [Fact]
        public void Test01()
        {
            Part01 part01 = new();

            int possibilities = part01.MultiplyPossibilities();

            //Assert.Equal(288, possibilities);

            Assert.Equal(74698, possibilities);

        }

        [Fact]
        public void Test02()
        {
            Part02 part02 = new();

            long possibilities = part02.SumPossibilitiesWin();

            Assert.Equal(71503, possibilities);
        }
    }
}
