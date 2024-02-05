using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField]
    private GameObject followedObject;

    [SerializeField]
    private Vector3 positionFromObject = new Vector3(0, 5, -10);

    private void Start()
    {
        FollowObject();
    }

    private void LateUpdate()
    {
        FollowObject();
    }

    private void FollowObject()
    {
        transform.position = followedObject.transform.position + positionFromObject;
    }
}
