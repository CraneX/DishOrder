using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dishes
{
    /// <summary>
    /// To store meal type and name mapping, we can expand it with multiple foods list
    /// </summary>
    internal static class Meals
    {
        /// <summary>
        /// morning meal list
        /// </summary>

        private static readonly IDictionary<DishType, string> morningMeal;
        
        /// <summary>
        /// night meal list
        /// </summary>
        private static readonly IDictionary<DishType, string> nightMeal;

        static Meals()
        {
            //we can load meal from xml or database
            morningMeal = new Dictionary<DishType, string>()
            {
                {DishType.Entree, "eggs"},
                {DishType.Side, "toast"},
                {DishType.Drink, "coffee"},
            };

            nightMeal = new Dictionary<DishType, string>()
            {
                {DishType.Entree, "steak"},
                {DishType.Side, "potato"},
                {DishType.Drink, "wine"},
                {DishType.Dessert, "cake"}
            };
        }

        /// <summary>
        /// Check which meal we can provide
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string Provide(DayTime dt, DishType type)
        {
            string meal;

            switch (dt)
            {
                case DayTime.Morning:
                    if (morningMeal.TryGetValue(type, out meal))
                    {
                        return meal;
                    }
                    break;
                case DayTime.Night:
                    if (nightMeal.TryGetValue(type, out meal))
                    {
                        return meal;
                    }
                    break;
                default:
                    break;
            }

            return null;
        }
    }
}
