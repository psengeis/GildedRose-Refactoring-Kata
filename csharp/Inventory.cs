using System.Collections.Generic;

namespace csharp
{
    public class Inventory
    {
        private readonly IEnumerable<Item> _items;

        public Inventory(IEnumerable<Item> items)
        {
            _items = items;
        }

        public void UpdateItemsForNextDay()
        {
            foreach (Item item in this._items)
            {
                SellInCalculator.UpdateForNextDay(item);
                QualityCalculator.UpdateForNextDay(item);
            }
        }
    }
}
