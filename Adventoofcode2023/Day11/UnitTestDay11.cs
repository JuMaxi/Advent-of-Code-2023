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

        [Fact]
        public void Test02()
        {
            Part02 part02 = new();

            long sum1 = part02.SumShortestPathBetweenGalaxies(); // 10 times
            //long sum2 = part02.SumShortestPathBetweenGalaxies(); // 100 times
            //long sum3 = part02.SumShortestPathBetweenGalaxies(); // 1000000 times


            Assert.Equal(1030, sum1);
            //Assert.Equal(8410, sum2);
            //Assert.Equal(82000210, sum3);


        }
    }
}
