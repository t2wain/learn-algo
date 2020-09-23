using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLib.Knapsack
{
    public class Item
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public double Value { get; set; }
        public double Quantity { get; set; }
        public bool IsOptimal { get; set; }
    }
}
