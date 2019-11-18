using System;
using System.Collections.Generic;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ToDo Sengeis: Do we need this?
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = GetInitialItems();

            var app = new GildedRose(Items);

            int days = 30;

            for (int currentDay = 0; currentDay <= days; currentDay++)
            {
                Console.WriteLine($"-------- day {currentDay} --------");
                Console.WriteLine("name, sellIn, quality");

                foreach (Item item in Items)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.WriteLine("");

                app.PrepareForNextDay();
            }
        }

        private static List<Item> GetInitialItems()
        {
            return new List<Item>{
                new Item {Name = Resources.PlusFiveDexterityVest, SellIn = 10, Quality = 20},
                new Item {Name = Resources.AgedBrie, SellIn = 2, Quality = 0},
                new Item {Name =  Resources.ElexirOfTheMongoose, SellIn = 5, Quality = 7},
                new Item {Name = Resources.Sulfuras, SellIn = 0, Quality = 80},
                new Item {Name = Resources.Sulfuras, SellIn = -1, Quality = 80},
                new Item {Name = string.Format(Resources.BackstagePasses, "TAFKAL80ETC"), SellIn = 15, Quality = 20},
                new Item {Name = string.Format(Resources.BackstagePasses, "TAFKAL80ETC"), SellIn = 10, Quality = 49},
                new Item {Name = string.Format(Resources.BackstagePasses, "TAFKAL80ETC"), SellIn = 5, Quality = 49},

				// this conjured item does not work properly yet
                // ToDo Sengeis: what does "work properly" mean?
				new Item {Name = Resources.ConjuredManaCake, SellIn = 3, Quality = 6}
            };
        }

    }
}
