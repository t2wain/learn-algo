using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoLib
{
    public class Knapsack
    {

        #region Data Classes

        public class Item
        {
            public int Id { get; set; }
            public int Weight { get; set; }
            public double Value { get; set; }
            public double Quantity { get; set; }
            public bool IsOptimal { get; set; }
        }

        public class Sack
        {
            public int Capacity { get; set; }
            public List<Item> AllItems { get; } = new List<Item>();
            public List<Item> Items { get; } = new List<Item>();
            public int TotalWeight { get; set; }
            public double TotalValue { get; set; }
            public int RemainCapacity
            {
                get
                {
                    var r = this.Capacity - this.TotalWeight;
                    return r > 0 ? r : 0;
                }
            }
            public void AddItem(Item i)
            {
                if (i.Weight + this.TotalWeight <= this.Capacity)
                {
                    this.TotalWeight += i.Weight;
                    this.TotalValue += i.Value;
                    this.Items.Add(i);
                }
            }
            public void AddItem(IEnumerable<Item> items)
            {
                foreach (var i in items)
                    this.AddItem(i);
            }
            public void SetContent(Sack s)
            {
                this.TotalValue = s.TotalValue;
                this.TotalWeight = s.TotalWeight;
                this.Items.Clear();
                this.Items.AddRange(s.Items);
            }
        }

        #endregion

        #region Test Sacks

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

        #endregion

        public static Sack Greedy(IEnumerable<Item> items, int sackCapacity, bool wholeItemOnly = false)
        {
            var s = new Sack { Capacity = sackCapacity };
            var q = items.OrderByDescending(i => i.Value / i.Weight);
            foreach (var i in q)
            {
                if ((s.TotalWeight + i.Weight) <= sackCapacity)
                {
                    s.TotalWeight += i.Weight;
                    s.TotalValue += i.Value;
                    i.Quantity = 1;
                    s.Items.Add(i);
                }
                else if (!wholeItemOnly && s.TotalWeight < s.Capacity)
                {
                    i.Quantity = (s.Capacity - s.TotalWeight) / i.Weight;
                    s.Items.Add(i);
                    s.TotalWeight += Convert.ToInt32(Math.Round(i.Quantity * i.Weight, 0));
                    s.TotalValue += (i.Quantity * i.Value);
                    break;
                }
                else break;
            }
            return s;
        }
    
        public static Sack DP(IEnumerable<Item> items, int sackCapacity)
        {
            // optimal solution from previous decision stage
            var prevStage = new List<Sack>();

            // intialize
            for (int c = 0; c <= sackCapacity; c++)
                prevStage.Add(new Sack { Capacity = c });

            // Add each item in sequence.
            // Each item is a decision in a sequence of decisions.
            foreach (var i in items)
            {
                var currStage = new List<Sack>();

                // intialize the current stage
                for (int c = 0; c <= sackCapacity; c++)
                    currStage.Add(new Sack { Capacity = c });

                // previous sack of current stage
                var ls = new Sack(); 

                for (var k = 0; k <= sackCapacity; k++)
                {
                    var cs = currStage[k]; // current stage
                    var ps = prevStage[k]; // previous stage
                    // Add item to sack
                    DPAddItemToSack(prevStage, cs, i);
                    // Pick a sack with a hightest value among
                    // the last stage, or previous sack, or current sack
                    if (ps.TotalValue > cs.TotalValue && ps.TotalValue > ls.TotalValue)
                        // select sack from previous stage
                        currStage[k] = ps;
                    if (ls.TotalValue > cs.TotalValue)
                        // select previous sack of current stage
                        cs.SetContent(ls);
                    ls = currStage[k];
                }

                prevStage = currStage;
            }

            return prevStage.OrderByDescending(s => s.TotalValue).First();
        }

        private static void DPAddItemToSack(List<Sack> prevStage, Sack cs, Item i)
        {
            cs.AddItem(i);
            var remainCapacity = cs.RemainCapacity;
            var rs = prevStage[remainCapacity];
            cs.AddItem(rs.Items);
        }
    }
}
