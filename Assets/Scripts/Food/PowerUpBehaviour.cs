using System.Collections.Generic;

namespace Food
{
    public class PowerUpBehaviour : FoodBehaviour
    {
        private static readonly int SCORE = 5;
        private ScoreFoodAction scoreFoodAction;
        private PowerUpAction powerUpAction;

        public new void Awake()
        {
            base.Awake();
            scoreFoodAction = foodActionFactory.GetScoreFoodAction(SCORE);
            powerUpAction = foodActionFactory.GetPowerUpAction();
        }

        public override List<FoodAction> Eat()
        {
            Destroy(gameObject);

            return new List<FoodAction> { scoreFoodAction, powerUpAction };
        }
    }

}