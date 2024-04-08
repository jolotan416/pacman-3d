using Food;
using UnityEngine;

namespace Food
{
    public class BaseFoodBehaviour : MonoBehaviour, FoodBehaviour
    {
        private static readonly int SCORE = 1;

        public int Eat()
        {
            Destroy(gameObject);

            return SCORE;
        }
    }
}