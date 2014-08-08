using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dishes.Tests
{
    [TestFixture]
    [Category("FoodTest")]
    public class FoodTest
    {
        public FoodTest()
        {
        }

        [TestFixtureSetUp]
        public void SetUpFixture()
        {
        }

        [TestCase(DayTime.Morning, DishType.Entree, 1, "eggs")]
        [TestCase(DayTime.Morning, DishType.Entree, 2, "eggs(x2)")]
        [TestCase(DayTime.Morning, DishType.Side, 3, "toast(x3)")]
        [TestCase(DayTime.Morning, DishType.Dessert, 1, null)]
        [TestCase(DayTime.Night, DishType.Dessert, 0, null)]
        public void TestFoodAsString(DayTime dt, DishType type, int number, string expectValue)
        {
            Food food = new Food(dt)
            {
                FoodType = type,
                Number = number
            };

            Assert.IsNotNull(food);
            Assert.AreEqual(food.ToString(), expectValue);
        }
    }
}
