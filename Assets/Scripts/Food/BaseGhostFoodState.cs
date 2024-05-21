using System.Collections.Generic;

namespace Food
{
    public class BaseGhostFoodState: GhostFoodState
    {
        private GhostFoodAction ghostFoodAction;

        public BaseGhostFoodState(FoodActionFactory foodActionFactory): base(foodActionFactory)
        {
            ghostFoodAction = foodActionFactory.GetGhostFoodAction();
        }

        public override List<FoodAction> Eat()
        {
            return new List<FoodAction> { ghostFoodAction };
        }
    }
}