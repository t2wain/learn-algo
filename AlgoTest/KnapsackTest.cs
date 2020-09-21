using System;
using System.Collections.Generic;
using System.Text;
using K = AlgoLib.Knapsack;
using Xunit;

namespace AlgoTest
{
    public class KnapsackTest
    {

        [Fact]
        public void ShouldCalcGreedy()
        {
            var items = new K.Item[]
            {
                new K.Item { Id = 1, Weight = 5, Value = 10 },
                new K.Item { Id = 2, Weight = 4, Value = 40 },
                new K.Item { Id = 3, Weight = 6, Value = 30 },
                new K.Item { Id = 4, Weight = 3, Value = 50 },
            };
            var s = K.Greedy(items, 10, true);
            Assert.Equal(90.0, s.TotalValue, 3);
            Assert.Equal(7, s.TotalWeight);
        }

        [Fact]
        public void ShouldCalcDP()
        {
            var items = new K.Item[]
            {
                new K.Item { Id = 1, Weight = 5, Value = 10 },
                new K.Item { Id = 2, Weight = 4, Value = 40 },
                new K.Item { Id = 3, Weight = 6, Value = 30 },
                new K.Item { Id = 4, Weight = 3, Value = 50 },
            };
            var s = K.DP(items, 10);
            Assert.Equal(90.0, s.TotalValue, 3);
            Assert.Equal(7, s.TotalWeight);
        }
    }
}
