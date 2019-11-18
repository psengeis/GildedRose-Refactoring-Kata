using NUnit.Framework;
using System.Collections.Generic;

namespace csharp.Tests
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void UpdatingForNextDay()
        {
            Item testItem = new Item
            {
                Name = "testItem",
                SellIn = 1,
                Quality = 3
            };

            IList<Item> Items = new List<Item> { testItem };

            GildedRose app = new GildedRose(Items);

            app.PrepareForNextDay();

            Assert.AreEqual(0, testItem.SellIn);
            Assert.AreEqual(2, testItem.Quality);
        }

        [Test]
        public void QualityReducedByTenAfterTenDaysBeforeSellInDate()
        {
            Item testItem = new Item
            {
                Name = "testItem",
                SellIn = 15,
                Quality = 15
            };

            int expectedQuality = testItem.Quality - 10;

            IList<Item> items = new List<Item> { testItem };

            GildedRose app = new GildedRose(items);

            for (int i = 0; i < 10; i++)
            {
                app.PrepareForNextDay();
            }

            Assert.AreEqual(expectedQuality, testItem.Quality);
        }

        [Test]
        public void SellInReducedByTenAfterTenDaysBeforeSellInDate()
        {
            Item testItem = new Item
            {
                Name = "testItem",
                SellIn = 15,
                Quality = 15
            };

            int expectedSellIn = testItem.SellIn - 10;

            IList<Item> items = new List<Item> { testItem };

            GildedRose app = new GildedRose(items);

            for (int i = 0; i < 10; i++)
            {
                app.PrepareForNextDay();
            }

            Assert.AreEqual(expectedSellIn, testItem.SellIn);
        }

        [Test]
        public void QualityReducedDoublesAfterSellInDate()
        {
            Item testItem = new Item
            {
                Name = "testItem",
                SellIn = 0,
                Quality = 30
            };

            int expectedQuality = testItem.Quality - 20;

            IList<Item> items = new List<Item> { testItem };

            GildedRose app = new GildedRose(items);

            for (int i = 0; i < 10; i++)
            {
                app.PrepareForNextDay();
            }

            Assert.AreEqual(expectedQuality, testItem.Quality);
        }
    }
}