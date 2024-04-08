using Food;
using UnityEngine;
using Utils;

public class PacmanFoodCollider : MonoBehaviour
{
    private LogUtils logUtils = new LogUtils("PacmanFoodCollider");

    private FoodObserver foodObserver;

    private void Start()
    {
        foodObserver = GameObject.FindGameObjectWithTag(Constants.GAME_CONTROLLER_TAG)
            .GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Constants.FOOD_TAG))
        {
            logUtils.LogDebug("Colliding with food with name: " + collision.gameObject.name);
            FoodBehaviour foodBehaviour = collision.gameObject.GetComponent<FoodBehaviour>();
            foodObserver.NotifyFoodEaten(foodBehaviour.Eat());
        }
    }
}
