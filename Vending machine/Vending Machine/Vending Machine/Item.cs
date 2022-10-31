using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    internal class Item
    {
        private string name;
        private int count;
        private double price;

        public Item(string name, int count, double price)
        {
            this.name = name;
            this.count = count; 
            this.price = price;
        }
            
        public string Name { get { return name; } }
        public int Count { get { return count; } }
        public double Price { get { return price; } }

       
        public bool CanBuy(Item item)
        {
            if(item.count > 0)
            {
                return true;
            }
            return false;
        }

        public void PrintItem(Item item)
        {
            Console.WriteLine(item.Name + " " + item.Price + " " + item.count);
        }

    }
}
