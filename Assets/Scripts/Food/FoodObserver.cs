using System.Collections.Generic;

namespace Food
{
    public interface FoodObserver
    {
        public void NotifyFoodEaten(List<FoodAction> foodActions);
    }
}