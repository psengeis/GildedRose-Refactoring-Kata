using NUnit.Framework;

namespace csharp.Tests
{
    [TestFixture]
    public class SulfurasTest
    {
        [Test]
        public void QualityDoesNotChange()
        {
            Item sulfuras = new Item
            {
                Name = Resources.Sulfuras,
                SellIn = 22,
                Quality = 80
            };

            int qualityBefore = sulfuras.Quality;

            for (int i = 0; i < 20; i++)
            {
                QualityCalculator.UpdateForNextDay(sulfuras);
                Assert.AreEqual(qualityBefore, sulfuras.Quality);
            }
        }
    }
}
