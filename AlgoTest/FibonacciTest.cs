using System;
using Xunit;
using AlgoLib;

namespace AlgoTest
{
    public class FibonacciTest
    {
        [Fact]
        public void ShouldCalculateRecursive()
        {
            int c = 0;
            var n = Fibonacci.Fr(28, ref c);
            Assert.Equal(317811, n);
        }

        [Fact]
        public void ShouldCalculateLoop()
        {
            var n = Fibonacci.Fl(28);
            Assert.Equal(317811, n);
        }

        [Fact]
        public void ShouldCalculateLoop2()
        {
            var n = Fibonacci.Fl2(28);
            Assert.Equal(317811, n);
        }


    }
}
