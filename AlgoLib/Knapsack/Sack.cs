using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLib.Knapsack
{
    public class Sack
    {
        public int Capacity { get; set; }
        public List<Item> AllItems { get; } = new List<Item>();
        public IDictionary<int, Item> Items { get; } = new Dictionary<int, Item>();
        public int TotalWeight { get; protected set; }
        public double TotalValue { get; protected set; }
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
            if (!this.Items.ContainsKey(i.Id)
                    && i.Weight + this.TotalWeight <= this.Capacity)
            {
                this.TotalWeight += i.Weight;
                this.TotalValue += i.Value;
                this.Items.Add(i.Id, i);
            }
        }
        public void AddItem(IEnumerable<Item> items)
        {
            foreach (var i in items)
                this.AddItem(i);
        }
        public void SetContent(Sack s)
        {
            this.Items.Clear();
            foreach (var i in s.Items)
                this.Items.Add(i);
            this.Capacity = s.Capacity;
            this.TotalValue = s.TotalValue;
            this.TotalWeight = s.TotalWeight;
        }
        public void Reset(int capacity)
        {
            this.Capacity = capacity;
            this.TotalValue = 0;
            this.TotalWeight = 0;
            this.Items.Clear();
        }

    }
}
