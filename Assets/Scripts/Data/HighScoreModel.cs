using System;

namespace Data
{
    [Serializable]
    public class HighScoreModel
    {
        private const int DEFAULT_HIGH_SCORE = 0;
        private const string DEFAULT_HIGH_SCORE_NAME = "None";

        public int highScore;
        public string highScoreName;

        public HighScoreModel(int highScore = DEFAULT_HIGH_SCORE, string highScoreName = DEFAULT_HIGH_SCORE_NAME)
        {
            this.highScore = highScore;
            this.highScoreName = highScoreName;
        }
    }
}
