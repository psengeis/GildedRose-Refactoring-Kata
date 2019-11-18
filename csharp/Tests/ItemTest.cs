using NUnit.Framework;

namespace csharp.Tests
{
    [TestFixture]
    public class ItemTest
    {
        [Test]
        public void QualityReducesByOneEveryDay()
        {
            Item item = new Item()
            {
                Name = "Test-Item",
                Quality = 10,
                SellIn = 30
            };

            int quality = item.Quality;

            for (int i = 0; i < 3; i++)
            {
                QualityCalculator.UpdateForNextDay(item);
                Assert.AreEqual(quality - 1, item.Quality);

                quality = item.Quality;
            }
        }

        [Test]
        public void QualityReducesByTwoIfSellInPassed()
        {
            Item item = new Item()
            {
                Name = "Test-Item",
                Quality = 10,
                SellIn = -1
            };

            int quality = item.Quality;

            for (int i = 0; i < 3; i++)
            {
                QualityCalculator.UpdateForNextDay(item);
                Assert.AreEqual(quality - 2, item.Quality);

                quality = item.Quality;
            }
        }

        [Test]
        public void QualityDoesNotGetBelowZero()
        {
            Item item = new Item()
            {
                Name = "Test-Item",
                Quality = 1,
                SellIn = 3
            };

            for (int i = 0; i < 5; i++)
            {
                QualityCalculator.UpdateForNextDay(item);
                Assert.GreaterOrEqual(0, item.Quality);
            }
        }
    }
}
