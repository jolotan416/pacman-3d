using System.Collections.Generic;

namespace Food
{
    public class PowerUpBehaviour : FoodBehaviour
    {
        private static readonly int SCORE = 5;
        private ScoreFoodAction scoreFoodAction;

        public new void Awake()
        {
            base.Awake();
            scoreFoodAction = foodActionFactory.GetScoreFoodAction(SCORE);
        }

        public override List<FoodAction> Eat()
        {
            Destroy(gameObject);

            return new List<FoodAction> { scoreFoodAction };
        }
    }

}