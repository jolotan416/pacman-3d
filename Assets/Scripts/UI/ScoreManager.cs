using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;

        public void UpdateScore(int score)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
