using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Data;
using Utils;

namespace UI {
    public class TitleScreenManager : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI highScoreText;

        [SerializeField]
        private TextMeshProUGUI nameText;

        private ScoreDataManager scoreDataManager;

        private void Start()
        {
            scoreDataManager = ScoreDataManager.getInstance();
            scoreDataManager.SubscribeToHighScore(UpdateHighScore);
        }

        public void PlayGame()
        {
            scoreDataManager.SetCurrentPlayerName(nameText.text);
            SceneManager.LoadScene(Constants.GAME_SCENE_INDEX);
        }

        private void UpdateHighScore(HighScoreModel highScoreModel)
        {
            highScoreText.text = "High Score: " + highScoreModel.highScoreName + " - " + highScoreModel.highScore;
        }
    }

}
