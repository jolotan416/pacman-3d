using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Ghost;

namespace Food {
    public class GhostFoodBehaviour : FoodBehaviour
    {
        private LogUtils logUtils = new LogUtils("GhostFoodBehaviour");

        private GhostFoodState ghostFoodState;

        public new void Awake()
        {
            base.Awake();
            ghostFoodState = new BaseGhostFoodState(foodActionFactory);
        }

        public void UpdateState(GhostState ghostState)
        {
            switch(ghostState)
            {
                case GhostState.BASE:
                    {
                        ghostFoodState = new BaseGhostFoodState(foodActionFactory);

                        break;
                    }
                case GhostState.NERFED:
                    {
                        ghostFoodState = new PowerUpGhostFoodState(foodActionFactory);

                        break;
                    }
            }
        }

        public override List<FoodAction> Eat()
        {
            logUtils.LogDebug("GhostFoodBehaviour Eat called.");
            return ghostFoodState.Eat();
        }
    }

}