using NUnit.Framework;
using MockingAndTestDrivenDepelopment;
using System;

namespace PromotionsTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PromotionShouldReturns30PercentDiscountWhenDayIsMonday()
        {
            DateTime dayMonday = new DateTime(2020,11,23);
            Promotion promotion = new Promotion(dayMonday);
            Assert.That(promotion.Get() == 30);
           
        }
    }
}