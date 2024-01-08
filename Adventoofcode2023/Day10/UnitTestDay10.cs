using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day10
{
    public class UnitTestDay10
    {
        [Fact]

        public void Test01()
        {
            Part01 part01 = new();

            //long sum = part01.Sum();

            //Assert.Equal(4, sum);

            long sum2 = part01.Sum();

            Assert.Equal(8, sum2);
        }
    }
}
                    