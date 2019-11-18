namespace csharp
{
    public static class SellInCalculator
    {
        public static void UpdateForNextDay(Item item)
        {
            if (item.Name == Resources.Sulfuras)
            {
                UpdateForSulfuras(item);
            }
            else
            {
                UpdateForNormalItem(item);
            }
        }

        private static void UpdateForNormalItem(Item item)
        {
            item.SellIn--;
        }

        private static void UpdateForSulfuras(Item item) { }
    }
}
