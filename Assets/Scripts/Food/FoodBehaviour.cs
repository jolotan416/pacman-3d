using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Food
{
    public abstract class FoodBehaviour: MonoBehaviour
    {
        protected FoodActionFactory foodActionFactory;

        public abstract List<FoodAction> Eat();

        public void Awake()
        {
            foodActionFactory = GameObject.FindGameObjectWithTag(Constants.GAME_CONTROLLER_TAG)
                .GetComponent<GameManager>();
        }
    }
}