using System.Collections.Generic;
using UnityEngine;

namespace Food
{
    public class BaseFoodBehaviour : FoodBehaviour
    {
        private static readonly int SCORE = 1;
        private ScoreFoodAction scoreFoodAction;
        private CheckFoodObjectsAction checkFoodObjectsAction;

        public new void Awake()
        {
            base.Awake();
            scoreFoodAction = foodActionFactory.GetScoreFoodAction(SCORE);
            checkFoodObjectsAction = foodActionFactory.GetCheckFoodObjectsAction();
        }

        public override List<FoodAction> Eat()
        {
            Destroy(gameObject);

            return new List<FoodAction> { scoreFoodAction, checkFoodObjectsAction };
        }
    }
}