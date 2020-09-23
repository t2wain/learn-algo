using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoLib.Knapsack
{
    public class Sacks
    {
        List<Sack> _sacks;

        public Sacks()
        {
            var s = new Sack();
            this._sacks = new List<Sack>();
            this._sacks.Add(s);
            this.MaxSack = s;
        }

        public Sack MaxSack { get; protected set; }

        public Sack GetSackByCapacity(int capacity)
        {
            Sack s = new Sack();
            foreach (var i in this._sacks)
            {
                // get the largest saved capacity
                // that does not exceed the requested capacity
                // since not all capcities are saved
                // because they have the same values.
                if (i.Capacity > capacity)
                    break;
                s = i;
            }
            return s;
        }

        public void SaveLargerSack(Sack s)
        {
            // only store the sack if
            // the value is higher than the last
            // saved capacity to reduce memory
            if (s.TotalValue > this.MaxSack.TotalValue)
            {
                // higher values found
                // since the last saved capacity
                var ns = new Sack();
                ns.SetContent(s);
                this._sacks.Add(ns);
                this.MaxSack = ns;
            }
        }

    }
}
