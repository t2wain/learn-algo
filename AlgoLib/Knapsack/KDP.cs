using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoLib.Knapsack
{
    public class KDP
    {
        public static Sack AddItems(IEnumerable<Item> items, 
            int sackCapacity, int capacityIncrement = 1)
        {
            // optimal solution from previous decision stage
            var prevStage = new Sacks();
            var cs = new Sack();

            // Add each item in sequence.
            // Each item is a decision in a sequence of decisions.
            foreach (var i in items)
            {
                var currStage = new Sacks();
                // max value the current stage can obtain
                var maxValue = prevStage.MaxSack.TotalValue + i.Value;

                for (var k = 0; k <= sackCapacity; k += capacityIncrement)
                {
                    cs.Reset(k); // current stage
                    var ps = prevStage.GetSackByCapacity(k); // previous stage
                    // Add item to sack
                    DPAddItemToSack(prevStage, cs, i);
                    // Pick a sack with a hightest value among
                    // the last stage or current sack
                    currStage.SaveLargerSack(ps.TotalValue > cs.TotalValue ? ps : cs);
                    if (cs.TotalValue + 0.01 > maxValue)
                        // reduce search space
                        break; // max value is obtained
                }

                prevStage = currStage;
            }

            return prevStage.MaxSack;
        }

        private static void DPAddItemToSack(Sacks prevStage, Sack cs, Item i)
        {
            if (i.Weight <= cs.Capacity)
            {
                cs.AddItem(i);
                var remainCapacity = cs.RemainCapacity;
                var rs = prevStage.GetSackByCapacity(remainCapacity);
                if (rs.TotalValue > 0)
                    cs.AddItem(rs.Items);
            }
        }

    }
}
