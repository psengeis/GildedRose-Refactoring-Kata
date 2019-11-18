using System;
using System.Collections.Generic;

namespace csharp
{
    public static class QualityCalculator
    {
        private static readonly Dictionary<string, int> _customMaxQualities = new Dictionary<string, int>()
        {
            { Resources.Sulfuras, 80 }
        };

        private static readonly int _defaultMaxQuality = 50;

        public static void UpdateForNextDay(Item item)
        {
            if (item.Name == Resources.AgedBrie)
            {
                UpdateForAgedBrie(item);
            }
            else if (item.Name == Resources.Sulfuras)
            {
                UpdateForSulfuras(item);
            }
            else if (IsBackstagepass(item))
            {
                UpdateForBackstagePass(item);
            }
            else
            {
                UpdateForNormalItem(item);
            }

            int itemsMaxQuality = GetMaxQaulity(item);
            item.Quality = Math.Min(item.Quality, itemsMaxQuality);
        }

        private static void UpdateForNormalItem(Item item)
        {
            if (item.Quality > 0)
            {
                int qualityReduce = 1;

                if (item.SellIn < 0)
                {
                    qualityReduce = 2;
                }

                item.Quality = Math.Max(item.Quality - qualityReduce, 0);
            }
        }

        private static void UpdateForAgedBrie(Item item)
        {
            if (item.SellIn < 0)
            {
                item.Quality += 2;
            }
            else
            {
                item.Quality++;
            }

            int itemsMaxQuality = GetMaxQaulity(item);
            item.Quality = Math.Min(item.Quality, itemsMaxQuality);
        }

        private static void UpdateForBackstagePass(Item item)
        {
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
            else if (item.SellIn < 5)
            {
                item.Quality = item.Quality + 3;
            }
            else if (item.SellIn < 10)
            {
                item.Quality = item.Quality + 2;
            }
            else
            {
                item.Quality++;
            }
        }

        private static void UpdateForSulfuras(Item item) { }


        private static int GetMaxQaulity(Item item)
        {
            int maxQualityForItem = 0;

            if (_customMaxQualities.TryGetValue(item.Name, out int customMaxQuality))
            {
                maxQualityForItem = customMaxQuality;
            }
            else
            {
                maxQualityForItem = _defaultMaxQuality;
            }

            return maxQualityForItem;
        }

        private static bool IsBackstagepass(Item item)
        {
            bool isBackstagepass = item.Name.StartsWith("Backstage passes to a ") && item.Name.EndsWith("concert");

            return isBackstagepass;
        }
    }
}
