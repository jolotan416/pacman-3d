using System.Collections.Generic;

namespace Food
{
    public class PowerUpGhostFoodState: GhostFoodState
    {
        private static readonly int SCORE = 10;
        private ScoreFoodAction scoreFoodAction;

        public PowerUpGhostFoodState(FoodActionFactory foodActionFactory): base(foodActionFactory)
        {
            scoreFoodAction = foodActionFactory.GetScoreFoodAction(SCORE);
        }

        public override List<FoodAction> Eat()
        {
            return new List<FoodAction> { scoreFoodAction };
        }
    }
}