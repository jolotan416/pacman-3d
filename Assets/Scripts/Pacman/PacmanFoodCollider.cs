using Food;
using UnityEngine;
using Utils;

namespace Pacman
{
    public class PacmanFoodCollider : MonoBehaviour
    {
        private LogUtils logUtils = new LogUtils("PacmanFoodCollider");

        private FoodObserver foodObserver;

        private void Start()
        {
            foodObserver = GameObject.FindGameObjectWithTag(Constants.GAME_CONTROLLER_TAG)
                .GetComponent<GameManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Constants.FOOD_TAG))
            {
                logUtils.LogDebug("Colliding with food with name: " + other.gameObject.name);
                FoodBehaviour foodBehaviour = other.gameObject.GetComponent<FoodBehaviour>();
                foodObserver.NotifyFoodEaten(foodBehaviour.Eat());
            }
        }
    }

}