using System;
using Utils;

namespace Food
{
    public class PowerUpAction : FoodAction
    {
        private LogUtils logUtils = new LogUtils("PowerUpAction");
        private Action powerUpCallback;

        public PowerUpAction(Action powerUpCallback)
        {
            this.powerUpCallback = powerUpCallback;
        }

        public void PerformAction()
        {
            logUtils.LogDebug("Performing power up action...");
            powerUpCallback();
        }
    }
}