
namespace Dishes
{
    public interface IRules
    {
        bool IsAllow(DayTime dt, DishType type, int number);
    }
}
