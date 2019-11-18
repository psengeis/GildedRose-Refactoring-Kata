using NUnit.Framework;

namespace csharp.Tests
{
    [TestFixture]
    public class BackstageTest
    {
        [Test]
        public void QualityIncreasesByOneOverTenDaysBeforeEvent()
        {
            Item backstagePass = new Item()
            {
                Name = string.Format(Resources.BackstagePasses, "XYZ"),
                Quality = 20,
                SellIn = 20
            };

            int expectedQuality = backstagePass.Quality + 1;
            QualityCalculator.UpdateForNextDay(backstagePass);

            Assert.AreEqual(expectedQuality, backstagePass.Quality);
        }

        [Test]
        public void QualityIncreasesByTwoBetweenFiveAndTenDaysBeforeEvent()
        {
            Item backstagePass = new Item()
            {
                Name = string.Format(Resources.BackstagePasses, "XYZ"),
                Quality = 10,
                SellIn = 7
            };

            int expectedQuality = backstagePass.Quality + 2;
            QualityCalculator.UpdateForNextDay(backstagePass);

            Assert.AreEqual(expectedQuality, backstagePass.Quality);
        }


        [Test]
        public void QualityIncreasesByThreeFiveDaysBeforeEvent()
        {
            Item backstagePass = new Item()
            {
                Name = string.Format(Resources.BackstagePasses, "XYZ"),
                Quality = 5,
                SellIn = 4
            };

            int expectedQuality = backstagePass.Quality + 3;
            QualityCalculator.UpdateForNextDay(backstagePass);

            Assert.AreEqual(expectedQuality, backstagePass.Quality);
        }


        [Test]
        public void QualityReducedToZeroAfterEvent()
        {
            Item backstagePass = new Item()
            {
                Name = string.Format(Resources.BackstagePasses, "XYZ"),
                Quality = 40,
                SellIn = -1
            };

            QualityCalculator.UpdateForNextDay(backstagePass);

            Assert.AreEqual(0, backstagePass.Quality);
        }
    }
}
