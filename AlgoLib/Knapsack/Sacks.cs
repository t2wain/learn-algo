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
            this._sacks = new List<Sack>();
            this._sacks.Add(new Sack());
        }

        public Sack MaxSack { get; protected set; } = new Sack();

        public Sack GetSackByCapacity(int capacity)
        {
            Sack s = new Sack();
            foreach (var i in this._sacks)
            {
                if (i.Capacity > capacity)
                    break;
                s = i;
            }
            return s;
        }

        public void SaveLargerSack(Sack currSack, Sack prevSack)
        {
            Sack ns = null;
            var ls = this._sacks.Last();
            if (currSack.TotalValue > prevSack.TotalValue 
                && currSack.TotalValue > ls.TotalValue)
            {
                ns = new Sack();
                ns.SetContent(currSack);
            }
            else if (prevSack.TotalValue > currSack.TotalValue 
                && prevSack.TotalValue > ls.TotalValue)
            {
                ns = new Sack();
                ns.SetContent(prevSack);
                ns.Capacity = currSack.Capacity;
            }
            if (ns != null)
            {
                this._sacks.Add(ns);
                this.MaxSack = ns;
            }
        }

    }
}
