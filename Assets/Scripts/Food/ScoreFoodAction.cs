using System;
using Utils;

namespace Food
{
    public class ScoreFoodAction: FoodAction
    {
        private LogUtils logUtils = new LogUtils("ScoreFoodAction");

        private int score = 0;
        private Action<int> handleScoreCallback;

        public ScoreFoodAction(int score, Action<int> handleScoreCallback)
        {
            this.score = score;
            this.handleScoreCallback = handleScoreCallback;
        }

        public void PerformAction()
        {
            logUtils.LogDebug("Performing action for ScoreFoodAction");
            handleScoreCallback(score);
        }
    }
}