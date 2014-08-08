using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dishes.Tests
{
    [TestFixture]
    [Category("MealsTest")]
    class MealsTest
    {
        public MealsTest()
        {
        }

        [TestFixtureSetUp]
        public void SetUpFixture()
        {
        }

        [TestCase(DayTime.Morning, DishType.Entree, "eggs")]
        [TestCase(DayTime.Morning, DishType.Side, "toast")]
        [TestCase(DayTime.Morning, DishType.Drink, "coffee")]
        [TestCase(DayTime.Morning, DishType.Dessert, null)]
        [TestCase(DayTime.Night, DishType.Entree, "steak")]
        [TestCase(DayTime.Night, DishType.Side, "potato")]
        [TestCase(DayTime.Night, DishType.Drink, "wine")]
        [TestCase(DayTime.Night, DishType.Dessert, "cake")]
        public void ProviderTest(DayTime dt, DishType type, string expectValue)
        {
            Assert.AreEqual(Meals.Provide(dt, type), expectValue);
        }
    }
}
