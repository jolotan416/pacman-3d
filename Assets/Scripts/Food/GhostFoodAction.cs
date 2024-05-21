using UnityEngine;
using Utils;

namespace Food
{
    public class GhostFoodAction : FoodAction
    {
        private LogUtils logUtils = new LogUtils("GhostFoodAction");

        public void PerformAction()
        {
            logUtils.LogDebug("Pacman dead. Stopping game...");
            Time.timeScale = 0;
        }
    }

}