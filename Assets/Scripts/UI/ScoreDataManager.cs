using System;
using System.Collections.Generic;
using UnityEngine;
using Data;
using System.IO;

namespace UI
{
    public class ScoreDataManager: MonoBehaviour
    {
        private static readonly string HIGH_SCORE_FILE_PATH = "high_score.txt";
        private static ScoreDataManager INSTANCE = null;

        public HighScoreModel highScoreModel { get; set; } = new HighScoreModel();
        public List<Action<HighScoreModel>> highScoreModelCallbacks = new List<Action<HighScoreModel>> { };
        private string currentPlayerName;

        public static ScoreDataManager getInstance()
        {
            return INSTANCE;
        }

        private void Awake()
        {
            INSTANCE = this;
            ReadHighScore();
            DontDestroyOnLoad(this.gameObject);
        }

        public void SetCurrentPlayerName(string currentPlayerName)
        {
            this.currentPlayerName = currentPlayerName;
        }

        public void CheckAndUpdateHighScore(int score)
        {
            if (score <= highScoreModel.highScore) return;

            highScoreModel = new HighScoreModel(score, currentPlayerName);

            string highScoreModelJson = JsonUtility.ToJson(highScoreModel);
            File.WriteAllText(GetHighScoreFilePath(), highScoreModelJson);
            UpdateHighScoreModelCallbacks();
        }

        public void SubscribeToHighScore(Action<HighScoreModel> highScoreModelCallback)
        {
            highScoreModelCallbacks.Add(highScoreModelCallback);
            highScoreModelCallback(highScoreModel);
        }

        private void ReadHighScore()
        {
            if (!File.Exists(GetHighScoreFilePath())) return;

            string highScoreFileText = File.ReadAllText(GetHighScoreFilePath());
            highScoreModel = JsonUtility.FromJson<HighScoreModel>(highScoreFileText);
            UpdateHighScoreModelCallbacks();
        }

        private void UpdateHighScoreModelCallbacks()
        {
            foreach (Action<HighScoreModel> highScoreModelCallback in highScoreModelCallbacks)
            {
                highScoreModelCallback(highScoreModel);
            }
        }

        private string GetHighScoreFilePath()
        {
            return Application.persistentDataPath +
                Path.DirectorySeparatorChar + HIGH_SCORE_FILE_PATH;
        }
    }
}