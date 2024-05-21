using System.Collections.Generic;

namespace Food
{
    public abstract class GhostFoodState
    {
        protected FoodActionFactory foodActionFactory;
        public GhostFoodState(FoodActionFactory foodActionFactory)
        {
            this.foodActionFactory = foodActionFactory;
        }

        public abstract List<FoodAction> Eat();
    }
}