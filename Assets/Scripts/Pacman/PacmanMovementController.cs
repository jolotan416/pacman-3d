using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Pacman
{
    public class PacmanMovementController : MonoBehaviour
    {
        [SerializeField]
        private float movementSpeed = 5f;

        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += new Vector3(
                Input.GetAxis(Constants.HORIZONTAL_AXIS) * movementSpeed,
                0f,
                Input.GetAxis(Constants.VERTICAL_AXIS) * movementSpeed);
        }
    }
}