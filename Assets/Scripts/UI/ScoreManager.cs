using TMPro;
using UnityEngine;
using Data;

namespace UI
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;

        [SerializeField]
        private TextMeshProUGUI highScoreText;

        private ScoreDataManager scoreDataManager;
        private int score = 0;

        private void Start()
        {
            scoreDataManager = ScoreDataManager.getInstance();
            scoreDataManager.SubscribeToHighScore(UpdateHighScore);
        }

        public void AddScore(int addedScore)
        {
            score += addedScore;
            scoreText.text = "Score: " + score;
        }

        public void VerifyHighScore()
        {
            scoreDataManager.CheckAndUpdateHighScore(score);
        }

        private void UpdateHighScore(HighScoreModel highScoreModel)
        {
            highScoreText.text = "High Score: " + highScoreModel.highScoreName + 
                " - " + highScoreModel.highScore;
        }
    }
}
