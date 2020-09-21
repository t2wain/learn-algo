using System;
using System.Collections.Generic;
using System.Text;
using K = AlgoLib.Knapsack;
using Xunit;
using System.Linq;

namespace AlgoTest
{
    public class KnapsackTest
    {

        private IEnumerable<K.Item> GetItemSet1() 
        {
            return new K.Item[]
                        {
                new K.Item { Id = 1, Weight = 23, Value = 92 , IsOptimal = true },
                new K.Item { Id = 2, Weight = 31, Value = 57 , IsOptimal = true },
                new K.Item { Id = 3, Weight = 29, Value = 49 , IsOptimal = true },
                new K.Item { Id = 4, Weight = 44, Value = 68 , IsOptimal = true },
                new K.Item { Id = 5, Weight = 53, Value = 60 },
                new K.Item { Id = 6, Weight = 38, Value = 43 , IsOptimal = true },
                new K.Item { Id = 7, Weight = 63, Value = 67 },
                new K.Item { Id = 8, Weight = 85, Value = 84 },
                new K.Item { Id = 9, Weight = 89, Value = 87 },
                new K.Item { Id = 10, Weight = 82, Value = 72 },
            };
        }

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

        [Fact]
        public void ShouldCalcDP2()
        {
            var items = GetItemSet1();
            var s = K.DP(items, 165);
            var v = items.Where(i => i.IsOptimal).Sum(i => i.Value);
            var w = items.Where(i => i.IsOptimal).Sum(i => i.Weight);
            Assert.Equal(5, s.Items.Count());
        }
    }
}
