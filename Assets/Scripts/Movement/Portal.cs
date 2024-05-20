using Utils;
using UnityEngine;

namespace Movement
{
    public class Portal : MonoBehaviour
    {
        [SerializeField]
        private GameObject teleportObject;

        [SerializeField]
        private Vector3 teleportOffsetPosition;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Constants.PLAYER_TAG) || other.gameObject.CompareTag(Constants.GHOST_TAG))
            {
                Vector3 gameObjectPosition = other.gameObject.transform.position;
                Vector3 newPosition = teleportObject.transform.position + teleportOffsetPosition;
                newPosition.y = gameObjectPosition.y;

                other.gameObject.transform.position = newPosition;
            }
        }
    }
}