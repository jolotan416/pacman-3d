using UnityEngine;
using Utils;
using UI;
using System.Collections.Generic;
using Food;
using Ghost;

public class GameManager : MonoBehaviour, FoodActionFactory, FoodObserver
{
    private LogUtils logUtils = new LogUtils("GameManager");

    [SerializeField]
    private GameObject gameOverScreen;

    private ScoreManager scoreManager;

    public void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag(Constants.SCORE_MANAGER_TAG)
            .GetComponent<ScoreManager>();
    }

    public ScoreFoodAction GetScoreFoodAction(int score)
    {
        return new ScoreFoodAction(score, AddScore);
    }

    public GhostFoodAction GetGhostFoodAction()
    {
        return new GhostFoodAction(GameOver);
    }

    public PowerUpAction GetPowerUpAction()
    {
        return new PowerUpAction(PowerUp);
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
        scoreManager.AddScore(addedScore);
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        scoreManager.VerifyHighScore();
        gameOverScreen.SetActive(true);
    }

    private void PowerUp()
    {
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag(Constants.GHOST_TAG);
        foreach (GameObject ghost in ghosts)
        {
            ghost.GetComponent<GhostStateManager>().PowerUp();
        }
    }
}
