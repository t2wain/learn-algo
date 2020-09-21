using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoLib
{
    public class Knapsack
    {

        #region Others

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
            public List<Item> Items { get; } = new List<Item>();
            public int TotalWeight { get; set; }
            public double TotalValue { get; set; }
        }

        public static IEnumerable<Item> GetItems()
        {
            return new Item[]
            {
                new Item { Id = 1, Weight = 5, Value = 10 },
                new Item { Id = 2, Weight = 4, Value = 40 },
                new Item { Id = 3, Weight = 6, Value = 30 },
                new Item { Id = 4, Weight = 3, Value = 50 },
            };
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
            // optimal solution from previous decision
            var prevStage = new List<Sack>();

            // intialize
            for (int c = 0; c <= sackCapacity; c++)
                prevStage.Add(new Sack { Capacity = c });

            // making decision is stages
            foreach (var i in items)
            {
                var currStage = new List<Sack>();

                // intialize the current stage
                for (int c = 0; c <= sackCapacity; c++)
                    currStage.Add(new Sack { Capacity = c });

                for (var k = 0; k <= sackCapacity; k++)
                {
                    var cs = currStage[k]; // current stage
                    var ps = prevStage[k]; // previous stage
                    if (i.Weight > cs.Capacity)
                        // use solution from previous stage
                        currStage[k] = ps;
                    else if (i.Value > ps.TotalValue || i.Weight + ps.TotalWeight <= cs.Capacity)
                    {
                        // found better solution
                        cs.TotalWeight = i.Weight;
                        cs.TotalValue = i.Value;
                        cs.Items.Add(i);

                        var remainCapacity = cs.Capacity - i.Weight;
                        if (remainCapacity > 0)
                        {
                            var rs = prevStage[remainCapacity];
                            if (rs.TotalValue > 0)
                            {
                                cs.Items.AddRange(rs.Items);
                                cs.TotalWeight += rs.TotalWeight;
                                cs.TotalValue += rs.TotalValue;
                            }
                        }
                    }
                    else if (currStage[k - 1].TotalValue > ps.TotalValue)
                    {
                        var t = currStage[k - 1];
                        cs.TotalWeight = t.TotalWeight;
                        cs.TotalValue = t.TotalValue;
                        cs.Items.AddRange(t.Items);
                    }
                    else currStage[k] = ps;
                }

                prevStage = currStage;
            }

            return prevStage.OrderByDescending(s => s.TotalValue).First();
        }
    }
}
