using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day08
{
    public class UnitTestDay08
    {
        [Fact]
        public void Test1()
        {
            Part01 part01 = new();

            long Steps = part01.SumSteps();

            //Assert.Equal(2, Steps);
            Assert.Equal(6, Steps);

        }
        [Fact]
        public void Test2()
        {
            Part02 part02 = new();

            long Steps = part02.SumMMCDivisibleNumbers();

            Assert.Equal(6, Steps);
        }
    }
}
