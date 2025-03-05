using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] products = {
                {"Laptop", "Electronics", "50000", "5"},
                {"Phone", "Electronics", "30000", "10"},
                {"Shirt", "Clothing", "1500", "20"},
                {"Shoes", "Footwear", "4000", "15"},
                {"Book", "Stationery", "800", "25"}
            };

            Console.WriteLine("Product Inventory:");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Name\tCategory\tPrice\tQuantity");
            Console.WriteLine("-------------------------------------------------------------"); 

           for (int i = 0; i < 5; i++)
            {
                string name = products[i, 0];
                string category = products[i, 1];
                double price = Convert.ToDouble(products[i, 2]);
                int quantity = Convert.ToInt32(products[i, 3]);

              Console.WriteLine(name+ "\t" +category + "\t"  + price + "\t" + quantity);
            }

            Console.WriteLine("\nTotal Stock Value:");
   
            foreach (var product in products)
            {
                for (int j = 0; j < 5 ; j++)
                {
                    double price = Convert.ToDouble(products[j, 2]);
                    int quantity = Convert.ToInt32(products[j, 3]);
                    double totalValue = price * quantity;
                    Console.WriteLine(products[j,0] + ":" + totalValue);
                } break;
            }

            Console.ReadKey();
        }
    }
}
