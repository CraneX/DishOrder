using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Dishes
{
    /// <summary>
    /// Food class, to contains the number of dish type
    /// </summary>
    internal class Food
    {
        private DayTime dayTime;

        public Food(DayTime dt)
        {
            this.dayTime = dt; 
        }

        public DishType FoodType
        {
            get;
            set;
        }

        public int Number
        {
            get;
            set;
        }


        /// <summary>
        /// to ouptut food as string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = Meals.Provide(this.dayTime, FoodType);
            if (!string.IsNullOrEmpty(s))
            {
                if (Number > 1)
                {
                    return string.Format(CultureInfo.InvariantCulture, "{0}(x{1})", s, Number);
                }
                else if (Number > 0)
                {
                    return s;
                }
            }

            return null;
        }
    }
}
