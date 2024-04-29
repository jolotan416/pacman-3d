using Food;
using UnityEngine;
using Utils;
using UI;

public class GameManager : MonoBehaviour, FoodObserver
{
    private ScoreManager scoreManager;
    private int score = 0;

    public void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag(Constants.SCORE_MANAGER_TAG)
            .GetComponent<ScoreManager>();
        scoreManager.UpdateScore(score);
    }

    public void NotifyFoodEaten(int foodValue)
    {
        score += foodValue;
        scoreManager.UpdateScore(score);
    }
}
