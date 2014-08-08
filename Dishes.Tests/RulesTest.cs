using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dishes.Tests
{
    [TestFixture]
    [Category("StringHelperTest")]
    public class RulesTest
    {
        public RulesTest()
        {
        }

        [TestFixtureSetUp]
        public void SetUpFixture()
        {
        }

        [TestCase(DayTime.Morning, DishType.Dessert, 1, false)]
        [TestCase(DayTime.Morning, DishType.Entree, 1, true)]
        [TestCase(DayTime.Morning, DishType.Entree, 2, false)]
        [TestCase(DayTime.Morning, DishType.Side, 1, true)]
        [TestCase(DayTime.Morning, DishType.Side, 2, false)]
        [TestCase(DayTime.Morning, DishType.Drink, 1, true)]
        [TestCase(DayTime.Morning, DishType.Drink, 2, true)]
        [TestCase(DayTime.Morning, DishType.Drink, 3, true)]
        [TestCase(DayTime.Night, DishType.Entree, 1, true)]
        [TestCase(DayTime.Night, DishType.Entree, 2, false)]
        [TestCase(DayTime.Night, DishType.Drink, 1, true)]
        [TestCase(DayTime.Night, DishType.Drink, 2, false)]
        [TestCase(DayTime.Night, DishType.Side, 1, true)]
        [TestCase(DayTime.Night, DishType.Side, 2, true)]
        [TestCase(DayTime.Night, DishType.Side, 3, true)]
        [TestCase(DayTime.Night, DishType.Side, 4, true)]
        [TestCase(DayTime.Night, DishType.Dessert, 1, true)]
        [TestCase(DayTime.Night, DishType.Dessert, 2, false)]
        public void IsAllowTest(DayTime dt, DishType type, int num, bool expectValue)
        {
            RulesImplement rule = new RulesImplement();
            Assert.AreEqual(rule.IsAllow(dt, type, num), expectValue);
        }
    }
}
