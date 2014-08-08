using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dishes
{
    /// <summary>
    /// Handle input text as Dish order, and print result
    /// </summary>
    public class DishOrder
    {
        private const string Error = "error";
        private const string Sep = ", "; //separator chars

        private static readonly ILog log = LogManager.GetLogger(typeof(DishOrder));

        private static IRules OrderRules;

        public DishOrder(IRules rules)
        {
            OrderRules = rules;
        }

        /// <summary>
        /// Print food result based on input require, output error if null/empty string/invalid input
        /// </summary>
        /// <param name="input">input command</param>
        /// <returns>food list</returns>
        public string PrintFoods(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                log.InfoFormat("input:{0}", input);

                string[] arr = StringHelper.Trim(input).Split(',');

                if (arr.Length <= 1)
                {
                    return Error;
                }

                // parse daytime, only allow morning|night input

                DayTime dt;
                bool error = !ParseDayTime(arr[0], out dt);

                if (!error)
                {
                    IDictionary<DishType, Food> foodList = new Dictionary<DishType, Food>();

                    // from the next input to parse food base on index
                    for (int i = 1, len = arr.Length; i < len; ++i)
                    {
                        DishType dish;
                        error = !ParseDishType(dt, arr[i], out dish);
                        if (error)
                        {
                            break;      //stop process on any error happened
                        }
                        else
                        {
                            //check is meet rule requirment
                            error = !MeetRequirement(dt, dish, foodList);
                            if (error)
                            {
                                break;  //stop process on any error happened
                            }
                        }

                    }

                    return PrintResult(error, foodList);
                }
            }

            return Error;
        }

        /// <summary>
        /// output food list
        /// </summary>
        /// <param name="error">parse status</param>
        /// <param name="foodList">food order list</param>
        /// <returns>food format list</returns>
        private string PrintResult(bool error, IDictionary<DishType, Food> foodList)
        {
            StringBuilder sb = new StringBuilder();

            if (foodList.Any())
            {
                //3.	The output must print food in the following order: entrée, side, drink, dessert

                IEnumerable<string> list =
                    foodList.Values.OrderBy(e => e.FoodType)
                    .Select(e => e.ToString())
                    .Where(e => !string.IsNullOrEmpty(e));

                sb.Append(string.Join<string>(Sep, list));
            }

            if (error)
            {
                if (foodList.Any())
                {
                    sb.Append(Sep);
                }

                sb.Append(Error);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Check the order is meet requirment or not
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="type">Dish type</param>
        /// <param name="foodList">food list</param>
        /// <returns>true on meet rule requirment, false on failed</returns>
        private bool MeetRequirement(DayTime dt, DishType type, IDictionary<DishType, Food> foodList)
        {
            int number = 1;

            //try to appened already exist order food
            Food f;
            if (foodList.TryGetValue(type, out f) && f != null)
            {
                number += f.Number;
            }

            if (OrderRules.IsAllow(dt, type, number))
            {
                if (f == null)
                {
                    foodList.Add(type,
                            new Food(dt)
                            {
                                FoodType = type,
                                Number = number
                            });
                }
                else
                {
                    f.Number = number;
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Parse dish type base on requriement daytime, dish type
        /// </summary>
        /// <param name="dt">day time</param>
        /// <param name="index">command index</param>
        /// <param name="dish">output dish type</param>
        /// <returns>true for prase correct, false on any error</returns>
        private bool ParseDishType(DayTime dt, string index, out DishType dish)
        {
            dish = DishType.Unknown;
            int n;
            if (int.TryParse(StringHelper.Trim(index), out n))
            {
                if (n > (int)DishType.Unknown && n <= (int)DishType.Dessert)
                {
                    dish = (DishType)n;

                    return dish != DishType.Unknown;
                }
            }

            return false;
        }

        /// <summary>
        /// Pase Day time
        /// </summary>
        /// <param name="input">input date time type, morning/night</param>
        /// <param name="dt">output datetime</param>
        /// <returns>true for prase correct, false on any error</returns>
        private bool ParseDayTime(string input, out DayTime dt)
        {
            if (Enum.TryParse<DayTime>(input, true, out dt)
                && (dt == DayTime.Morning || dt == DayTime.Night))
            {
                return true;
            }

            return false;
        }
    }
}
