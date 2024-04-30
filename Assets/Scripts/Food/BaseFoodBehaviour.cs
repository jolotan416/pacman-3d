using System.Collections.Generic;
using UnityEngine;

namespace Food
{
    public class BaseFoodBehaviour : FoodBehaviour
    {
        private static readonly int SCORE = 1;
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