using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Vending_Machine
{
    internal class VendingMachine
    {
        private List<Item> items = new List<Item>();
        private double inputSum;
        private double change;

        public VendingMachine()
        {
            this.items.Add(new Item("Soda",4, 1.5));
            this.items.Add(new Item("Water", 6, 0.4));
            this.items.Add(new Item("Croissant", 8, 4.7));
            this.items.Add(new Item("Donut", 2, 2.12));
            this.items.Add(new Item("Energy dring", 0, 2));
        }
        public List<Item> Items { get { return items; } }
   

    
    public void PrintItems()
        {
            for(int i = 0; i < items.Count; i++ )
            {
                Console.WriteLine((i+1).ToString() + " " + this.items[i].Name
                + "  - " + this.items[i].Price + "lv  - " + this.items[i].Count + "\n");
            }
        }

    private bool IsAvailable(Item item)
    {
            if (item.Count > 0)
            {
                return true;
            }
            return false;
    }
 

    public void VendingMachineInterface()
        {
            int input = 0;
            int s = 0;
            string sugar = "";
            PrintItems();
           
            try
                {   Console.WriteLine("\n Please insert money");
                    inputSum = Convert.ToDouble(Console.ReadLine());
                    if(inputSum < 0)
                    {
                    Console.WriteLine("Number is negative, sum converted to 0");
                    inputSum = 0;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n not number");
                    inputSum = 0;
                }

            Console.WriteLine("\n How much sugar would you like?");
            Console.WriteLine("\n \t 1 * no sugar");
            Console.WriteLine("\n \t 2 * standart");
            Console.WriteLine("\n \t 3 * double");
            do
            {
                try
                {
                    s = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n Number is out of range");
                }
            } while (s < 1 || s > 3);

            switch (s)
            {
                case 1:
                    sugar = "no sugar";
                    break;
                case 2:
                    sugar = "standart sugar";
                    break;
                case 3:
                    sugar = "double sugar";
                    break;
            }
            do
            {
                Console.WriteLine("\n \n Choose a item:");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException)
                {
                    Console.WriteLine("\n \n Number is out of range");
                }
            } while (input < 1 || input > items.Count);


            if (IsAvailable(items[input - 1]))
            {


                change = CalcChange(items[input - 1], inputSum);
               
                if (change > 0)
                {
                    Console.WriteLine("Your item is: " + items[input - 1].Name + " with " +sugar + ", Here's your change -   " + change + " lv" );
                }
                else if (change == 0)
                {
                    Console.WriteLine("Your item is: " + items[input - 1].Name +  " with " + sugar + ", you've given the exact amount needed ");
                }
                else
                {
                    do
                    {
                        Console.WriteLine(" Please insert more money!     Current amount : " + inputSum +" lv" + "     Amount goal : " + items[input - 1].Price + "lv");
                        inputSum = inputSum + Convert.ToDouble(Console.ReadLine());
                        change = CalcChange(items[input - 1], inputSum);

                    } while (change < 0);

                    Console.WriteLine("Your item is: " + items[input - 1].Name + "with " + sugar + ", Here's your change -  " + change + " lv");

                }
            }
            else { Console.WriteLine("Your item is currently sold out, here's your change -   " + inputSum + " lv"); }

            // item.PrintItem(item);
        }


    public double CalcChange(Item item, double inputSum)
        {
           return inputSum - item.Price; 
        }
    }
    
}
