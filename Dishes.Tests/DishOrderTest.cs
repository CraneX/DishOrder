using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dishes.Tests
{
    [TestFixture]
    [Category("DishOrderTest")]
    public class DishOrderTest
    {
        public DishOrderTest()
        {
        }

        [TestFixtureSetUp]
        public void SetUpFixture()
        {
        }

        [TestCase("", "error")]
        [TestCase(null, "error")]
        [TestCase("abc", "error")]
        [TestCase("morning", "error")]
        [TestCase("night", "error")]
        [TestCase("123", "error")]
        [TestCase("morning, 0, 2, 3", "error")]
        [TestCase("morning, 1, 2, 3", "eggs, toast, coffee")]
        [TestCase("morning, 2, 1, 3", "eggs, toast, coffee")]
        [TestCase("morning, 3, 2, 3, 1", "eggs, toast, coffee(x2)")]
        [TestCase("morning, 1, 2, 3, 4", "eggs, toast, coffee, error")]
        [TestCase("morning, 1, 2, 3, 3, 3", "eggs, toast, coffee(x3)")]
        [TestCase("night, 1, 2, 3, 4", "steak, potato, wine, cake")]
        [TestCase("night, 1, 2, 2, 4", "steak, potato(x2), cake")]
        [TestCase("night, 1, 2, 3, 5", "steak, potato, wine, error")]
        [TestCase("night, 1, 1, 2, 3, 5", "steak, error")]
        public void PrintFoodsTest(string input, string expectValue)
        {
            DishOrder order = new DishOrder();
            Assert.IsNotNull(order);

            string output = order.PrintFoods(input);
            Assert.AreEqual(output, expectValue);
        }
    }
}
