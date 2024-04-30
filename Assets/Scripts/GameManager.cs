using Food;
using UnityEngine;
using Utils;
using UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour, FoodActionFactory, FoodObserver
{
    private LogUtils logUtils = new LogUtils("GameManager");

    private ScoreManager scoreManager;
    private int score = 0;

    private ScoreFoodAction scoreFoodAction;

    public void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag(Constants.SCORE_MANAGER_TAG)
            .GetComponent<ScoreManager>();
        scoreManager.UpdateScore(score);
    }

    public ScoreFoodAction GetScoreFoodAction(int score)
    {
        return new ScoreFoodAction(score, AddScore);
    }

    public void NotifyFoodEaten(List<FoodAction> foodActions)
    {
        foodActions.ForEach(
            (foodAction) =>
            {
                foodAction.PerformAction();
            }
            );
    }

    private void AddScore(int addedScore)
    {
        logUtils.LogDebug("Added score: " + addedScore);
        score += addedScore;
        scoreManager.UpdateScore(score);
    }
}
