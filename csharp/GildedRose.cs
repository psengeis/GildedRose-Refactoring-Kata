using System.Collections.Generic;
using csharp;

namespace csharp
{
    public class GildedRose
    {
        private Inventory _inventory;

        public GildedRose(IEnumerable<Item> items)
        {
            _inventory = new Inventory(items);
        }

        public void PrepareForNextDay()
        {
            this._inventory.UpdateItemsForNextDay();
        }
    }
}
