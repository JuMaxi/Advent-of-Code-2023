﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventoofcode2023.Day03
{
    public class UnitTestDay03
    {
        [Fact]
        public void Test01()
        {
            Part01 part01 = new();

            int sum = part01.SumParts();

            Assert.Equal(4361, sum);
        }
    }
}
