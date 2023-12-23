﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day09
{
    public class UnitTestDay09
    {
        [Fact]
        public void Test01()
        {
            Part01 part01 = new();

            long sum = part01.SumExtrapolatedValues();

            Assert.Equal(114, sum);
        }
    }
}
