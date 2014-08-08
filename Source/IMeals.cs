using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dishes
{
    public interface IMeals
    {
        string Provide(DayTime dt, DishType type);
    }
}
