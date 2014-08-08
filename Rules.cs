using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dishes
{
    /// <summary>
    /// define the rules of dish order
    /// </summary>
    internal static class Rules
    {
        /// <summary>
        /// order rules for morning 
        /// </summary>
        private static readonly IDictionary<DishType, int> morningRules;

        /// <summary>
        /// order rules for night
        /// </summary>
        private static readonly IDictionary<DishType, int> nightRules;

        static Rules()
        {
            // we can loaded rules from xml or database
            morningRules = new Dictionary<DishType, int>()
            {
                {DishType.Dessert, 0}, //4.	There is no dessert for morning meals
                {DishType.Drink, int.MaxValue}, //7.	In the morning, you can order multiple cups of coffee
                {DishType.Entree, 1},   //9.	Except for the above rules, you can only order 1 of each dish type
                {DishType.Side, 1}      //9.	Except for the above rules, you can only order 1 of each dish type
            };

            nightRules = new Dictionary<DishType, int>()
            {
                {DishType.Side, int.MaxValue}  ,//8.	At night, you can have multiple orders of potatoes
                {DishType.Entree, 1},   //9.	Except for the above rules, you can only order 1 of each dish type
                {DishType.Drink, 1},    //9.	Except for the above rules, you can only order 1 of each dish type
                {DishType.Dessert, 1}   //9.	Except for the above rules, you can only order 1 of each dish type
            };


        }

        /// <summary>
        /// Can we allow order the number or dish type in time period
        /// </summary>
        /// <param name="dt">daytime input</param>
        /// <param name="type">dish type</param>
        /// <param name="number">order number</param>
        /// <returns>true of </returns>
        public static bool IsAllow(DayTime dt, DishType type, int number)
        {
            int n;
            switch (dt)
            {
                case DayTime.Morning:
                    if (morningRules.TryGetValue(type, out n)
                        && n > 0
                        && number <= n)
                    {
                        return true;
                    }
                    break;
                case DayTime.Night:
                    if (nightRules.TryGetValue(type, out n)
                      && n > 0
                      && number <= n)
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }


            return false;
        }
    }
}
