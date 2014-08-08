using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dishes
{
    public interface IRules
    {
        bool IsAllow(DayTime dt, DishType type, int number);
    }
}
