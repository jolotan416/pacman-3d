using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Pacman
{
    public class PacmanMovementController : MonoBehaviour
    {
        private static readonly float VERTICAL_ROTATION = 180f;
        private static readonly float HORIZONTAL_ROTATION = 90f;

        [SerializeField]
        private float movementSpeed = 5f;

        private Rigidbody rb;
        private float horizontalInput = 0f;
        private float verticalInput = 0f;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            float newHorizontalInput = Input.GetAxis(Constants.HORIZONTAL_AXIS);
            float newVerticalInput = Input.GetAxis(Constants.VERTICAL_AXIS);

            if (newHorizontalInput != 0f)
            {
                horizontalInput = Mathf.Sign(newHorizontalInput);
                verticalInput = 0f;
            } else if (newVerticalInput != 0f)
            {
                horizontalInput = 0f;
                verticalInput = Mathf.Sign(newVerticalInput);
            }

            RotateFromInput();
        }

        private void FixedUpdate()
        {
            MovePacman();
        }

        void RotateFromInput()
        {
            if (horizontalInput != 0)
            {
                transform.rotation = Quaternion.AngleAxis(
                    (horizontalInput > 0f) ? -HORIZONTAL_ROTATION : HORIZONTAL_ROTATION,
                    Vector3.up);

                return;
            }

            if (verticalInput != 0)
            {
                transform.rotation = Quaternion.AngleAxis(
                    (verticalInput > 0f) ? VERTICAL_ROTATION : 0f,
                    Vector3.up);
            }
        }

        void MovePacman()
        {
            if (horizontalInput != 0)
            {
                rb.AddForce(Vector3.right * movementSpeed * horizontalInput, ForceMode.VelocityChange);

                return;
            }

            if (verticalInput != 0)
            {
                rb.AddForce(Vector3.forward * movementSpeed * verticalInput, ForceMode.VelocityChange);
            }
        }
    }
}