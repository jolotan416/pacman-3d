using System;
using UnityEngine;
using Utils;

namespace Food
{
    public class GhostFoodAction : FoodAction
    {
        private LogUtils logUtils = new LogUtils("GhostFoodAction");
        private Action gameOverCallback;

        public GhostFoodAction(Action gameOverCallback)
        {
            this.gameOverCallback = gameOverCallback;
        }

        public void PerformAction()
        {
            logUtils.LogDebug("Pacman dead. Stopping game...");
            gameOverCallback();
        }
    }

}