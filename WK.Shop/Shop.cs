using System;
using System.Collections.Generic;
using System.Text;
using WK.Shop.Base;
using WK.Shop.DA;
using WK.Shop.Model;

namespace WK.Shop
{
    public class Shop : IShop
    {
        static void Main(string[] args)
        {
            /*****************************************************
             * SEED DATA - Could be read in as Json, XML, etc...
            *****************************************************/
            //Items1
            List<Item> items1 = new List<Item>();
            items1.Add(new Item { 
                Id = 1, Name = "book", 
                Price = 12.49M, 
                Quantity = 1, 
                IsImported = false, 
                Type = ItemType.Book });
            items1.Add(new Item { 
                Id = 2, 
                Name = "music CD", 
                Price = 14.99M, 
                Quantity = 1, 
                IsImported = false, 
                Type = ItemType.Other });
            items1.Add(new Item { 
                Id = 3, 
                Name = "chocolate bar", 
                Price = 0.85M, 
                Quantity = 1, 
                IsImported = false, 
                Type = ItemType.Food });

            //Items2
            List<Item> items2 = new List<Item>();
            items2.Add(new Item
            {
                Id = 4,
                Name = "imported box of chocolates",
                Price = 10.00M,
                Quantity = 1,
                IsImported = true,
                Type = ItemType.Food
            });
            items2.Add(new Item
            {
                Id = 5,
                Name = "imported bottle of purfume",
                Price = 47.50M,
                Quantity = 1,
                IsImported = true,
                Type = ItemType.Other
            });

            //Items3
            List<Item> items3 = new List<Item>();
            items3.Add(new Item
            {
                Id = 6,
                Name = "imported bottle of perfume",
                Price = 27.99M,
                Quantity = 1,
                IsImported = true,
                Type = ItemType.Other
            });
            items3.Add(new Item
            {
                Id = 7,
                Name = "bottle of perfume",
                Price = 18.99M,
                Quantity = 1,
                IsImported = false,
                Type = ItemType.Other
            });
            items3.Add(new Item
            {
                Id = 8,
                Name = "packet of headache pills",
                Price = 9.75M,
                Quantity = 1,
                IsImported = false,
                Type = ItemType.Medical
            });
            items3.Add(new Item
            {
                Id = 9,
                Name = "imported box of chocolates",
                Price = 11.25M,
                Quantity = 1,
                IsImported = true,
                Type = ItemType.Food
            });

            //Basket1
            Basket basket1 = new Basket 
            {
                Id = 0,
                Items = items1
            };
            
            //Basket2
            Basket basket2 = new Basket 
            {
                Id = 0,
                Items = items2
            };

            //Basket3
            Basket basket3 = new Basket 
            {
                Id = 0,
                Items = items3
            };

            //Populate Basket List
            List<Basket> baskets = new List<Basket>();
            baskets.Add(basket1);
            baskets.Add(basket2);
            baskets.Add(basket3);

            /**********************************
             * PROCESS BASKETS & PRINT RECIPTS
            **********************************/
            //StringBuilder used to print receipts to console
            StringBuilder sbBaskets = new StringBuilder().AppendLine("INPUT");
            StringBuilder sbReceipts = new StringBuilder().AppendLine("OUTPUT");
            foreach (var basket in baskets)
            {
                try
                {
                    // Print current basket
                    sbBaskets.AppendLine(basket.PrintBasket());

                    // Process the basket, apply tax calculation, receipt is returned
                    Receipt receipt = basket.ProcessBasket();

                    // Save updated Basket & Receipt
                    DABasket.UpsertBasket(basket);
                    DAReceipt.UpsertReceipt(receipt);

                    // Print Receipts
                    sbReceipts.AppendLine(receipt.PrintReceipt());
                }
                catch (Exception e)
                { }
                finally 
                { }
            }

            // Write to console
            Console.SetWindowSize(50, 50);
            Console.Write(sbBaskets.ToString());
            Console.Write(sbReceipts.ToString());
            // Pause for input
            Console.ReadLine();
        }
    }
}
