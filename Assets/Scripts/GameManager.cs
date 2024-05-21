using UnityEngine;
using UnityEngine.SceneManagement;
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
    private bool isGameOver = false;

    public void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag(Constants.SCORE_MANAGER_TAG)
            .GetComponent<ScoreManager>();
    }

    private void Update()
    {

        if (isGameOver && Input.GetKey(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(Constants.GAME_SCENE_INDEX);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(Constants.TITLE_SCREEN_SCENE_INDEX);
        }
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
        isGameOver = true;
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
