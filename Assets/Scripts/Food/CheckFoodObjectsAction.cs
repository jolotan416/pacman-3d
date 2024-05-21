using System;
using UnityEngine;
using Utils;

namespace Food
{
    public class CheckFoodObjectsAction : FoodAction
    {
        private LogUtils logUtils = new LogUtils("CheckFoodObjectsAction");
        private Action gameOverCallback;

        public CheckFoodObjectsAction(Action gameOverCallback)
        {
            this.gameOverCallback = gameOverCallback;
        }

        public void PerformAction()
        {
            int foodListLength = GameObject.FindGameObjectsWithTag(Constants.FOOD_TAG).Length;
            logUtils.LogDebug("Food list length: " + foodListLength);
            if (foodListLength == 1)
            {
                gameOverCallback();
            }
        }
    }
}