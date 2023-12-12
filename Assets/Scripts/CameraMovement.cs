using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject followedObject;

    [SerializeField]
    private Vector3 positionFromFollowedObject;

    private void LateUpdate()
    {
        transform.position = followedObject.transform.position + positionFromFollowedObject;
    }
}
