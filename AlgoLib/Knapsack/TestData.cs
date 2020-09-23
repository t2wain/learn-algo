using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoLib.Knapsack
{
    public class TestData
    {
        public static Sack GetTestSack1()
        {
            var s = new Sack { Capacity = 10 };
            var items = new Item[]
            {
                new Item { Id = 1, Weight = 5, Value = 10 },
                new Item { Id = 2, Weight = 4, Value = 40, IsOptimal = true },
                new Item { Id = 3, Weight = 6, Value = 30 },
                new Item { Id = 4, Weight = 3, Value = 50, IsOptimal = true },
            };
            s.AllItems.AddRange(items);
            s.AddItem(items.Where(i => i.IsOptimal));
            return s;
        }

        public static Sack GetTestSack2()
        {
            var s = new Sack { Capacity = 165 };
            var items = new Item[]
            {
                new Item { Id = 1, Weight = 23, Value = 92, IsOptimal = true },
                new Item { Id = 2, Weight = 31, Value = 57, IsOptimal = true },
                new Item { Id = 3, Weight = 29, Value = 49, IsOptimal = true },
                new Item { Id = 4, Weight = 44, Value = 68, IsOptimal = true },
                new Item { Id = 5, Weight = 53, Value = 60 },
                new Item { Id = 6, Weight = 38, Value = 43, IsOptimal = true },
                new Item { Id = 7, Weight = 63, Value = 67 },
                new Item { Id = 8, Weight = 85, Value = 84 },
                new Item { Id = 9, Weight = 89, Value = 87 },
                new Item { Id = 10, Weight = 82, Value = 72 },
            };
            s.AllItems.AddRange(items);
            s.AddItem(items.Where(i => i.IsOptimal));
            return s;
        }

    }
}
