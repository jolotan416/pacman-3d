using Utils;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private GameObject teleportObject;

    [SerializeField]
    private Vector3 teleportOffsetPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.PLAYER_TAG))
        {
            other.gameObject.transform.position = teleportObject.transform.position + teleportOffsetPosition;
        }
    }
}
