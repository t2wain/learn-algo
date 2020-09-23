using System;
using System.Collections.Generic;
using System.Text;
using K = AlgoLib.KnapsackA;
using K2 = AlgoLib.Knapsack.KDP;
using Xunit;
using System.Linq;

namespace AlgoTest
{
    public class KnapsackTest
    {
        [Fact]
        public void CalcGreedy1Optimal()
        {
            var d = K.GetTestSack1();
            var s = K.Greedy(d.AllItems, d.Capacity, true);
            Assert.Equal(d.TotalValue, s.TotalValue, 3);
            Assert.Equal(d.TotalWeight, s.TotalWeight);
        }

        [Fact]
        public void CalcDP1Optimal()
        {
            var d = K.GetTestSack1();
            var s = K.DP(d.AllItems, d.Capacity);
            Assert.Equal(d.TotalValue, s.TotalValue, 3);
            Assert.Equal(d.TotalWeight, s.TotalWeight);
        }

        [Fact]
        public void CalcDP2Optimal()
        {
            var d = K.GetTestSack2();
            var s = K.DP(d.AllItems, d.Capacity);
            Assert.Equal(d.Items.Count, s.Items.Count);
            Assert.Equal(d.TotalWeight, s.TotalWeight);
            Assert.Equal(d.TotalValue, s.TotalValue, 3);
        }

        [Fact]
        public void CalcGreedy2NotOptimal()
        {
            var d = K.GetTestSack2();
            var s = K.Greedy(d.AllItems, d.Capacity, true);
            Assert.True(s.TotalValue < d.TotalValue);
        }

        [Fact]
        public void CalcDP2Set1Optimal()
        {
            var d = K.GetTestSack1();
            var s = K.DP2(d.AllItems, d.Capacity);
            Assert.Equal(d.TotalValue, s.TotalValue, 3);
            Assert.Equal(d.TotalWeight, s.TotalWeight);
        }

        [Fact]
        public void CalcDP2Set2Optimal()
        {
            var d = K.GetTestSack2();
            var s = K.DP2(d.AllItems, d.Capacity);
            Assert.Equal(d.Items.Count, s.Items.Count);
            Assert.Equal(d.TotalWeight, s.TotalWeight);
            Assert.Equal(d.TotalValue, s.TotalValue, 3);
        }

        [Fact]
        public void CalcDP3Set2Optimal()
        {
            var d = K2.GetTestSack2();
            var s = K2.AddItems(d.AllItems, d.Capacity);
            Assert.Equal(d.TotalWeight, s.TotalWeight);
            Assert.Equal(d.TotalValue, s.TotalValue, 3);
        }

    }
}
