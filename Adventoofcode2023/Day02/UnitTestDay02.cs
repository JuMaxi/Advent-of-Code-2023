using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day02
{
    public class UnitTestDay02
    {
        [Fact]
        public void Test01()
        {
            Part01 part01 = new();
            
            int sum = part01.SumPossibleIds();

            Assert.Equal(8, sum);
        }
    }
}
