using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

namespace Pacman
{
    public class PacmanMovementController : MonoBehaviour
    {
        private static readonly float VERTICAL_ROTATION = 180f;
        private static readonly float HORIZONTAL_ROTATION = 90f;
        private static List<Direction> HORIZONTAL_DIRECTIONS =  new List<Direction>() { Direction.LEFT, Direction.RIGHT };
        private static List<Direction> VERTICAL_DIRECTIONS = new List<Direction>() { Direction.FORWARD, Direction.BACKWARD };

        [SerializeField]
        private float movementSpeed = 5f;

        private Rigidbody rb;

        private Direction currentDirection = Direction.NONE;
        private Direction pendingDirection = Direction.NONE;

        private bool hasPassedGateEntry = false;
        private List<Direction> directionChangeGateAllowedDirections = HORIZONTAL_DIRECTIONS;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Direction directionFromInput = GetDirectionFromInputs(
                Input.GetAxis(Constants.HORIZONTAL_AXIS),
                Input.GetAxis(Constants.VERTICAL_AXIS));

            UpdateDirection(directionFromInput);
        }

        private void FixedUpdate()
        {
            MovePacman();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerExit: " + other.tag);
            if (other.CompareTag(Constants.DIRECTION_CHANGE_ENTRY_TAG))
            {
                hasPassedGateEntry = false;
                if (HORIZONTAL_DIRECTIONS.Contains(currentDirection))
                {
                    directionChangeGateAllowedDirections = HORIZONTAL_DIRECTIONS;
                } else if (VERTICAL_DIRECTIONS.Contains(currentDirection))
                {
                    directionChangeGateAllowedDirections = VERTICAL_DIRECTIONS;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("OnTriggerExit: " + other.tag);
            if (other.CompareTag(Constants.DIRECTION_CHANGE_ENTRY_TAG))
            {
                hasPassedGateEntry = true;

                return;
            }

            if (other.CompareTag(Constants.DIRECTION_CHANGE_EXIT_TAG) && hasPassedGateEntry)
            {
                hasPassedGateEntry = false;
                directionChangeGateAllowedDirections = other.gameObject
                    .GetComponent<DirectionChangeGate>()
                    .allowedDirections;
                if (directionChangeGateAllowedDirections.Contains(pendingDirection))
                {
                    currentDirection = pendingDirection;
                    rb.velocity = Vector3.zero;
                    RotatePacman();
                }

                pendingDirection = Direction.NONE;
            }
        }

        private Direction GetDirectionFromInputs(float horizontalInput, float verticalInput)
        {
            if (horizontalInput != 0)
            {
                return (Mathf.Sign(horizontalInput) > 0) ? Direction.RIGHT : Direction.LEFT;
            }

            if (verticalInput != 0)
            {
                return (Mathf.Sign(verticalInput) > 0) ? Direction.FORWARD : Direction.BACKWARD;
            }

            return Direction.NONE;
        }

        private void UpdateDirection(Direction directionFromInput)
        {
            pendingDirection = Direction.NONE;

            if (directionFromInput == Direction.NONE || currentDirection == directionFromInput) return;

            Debug.Log("Update direction => directionFromInput: " + directionFromInput + 
                ", allowed directions: " + string.Join(", ", directionChangeGateAllowedDirections) + 
                ", currentDirection: " + currentDirection);
            if ((HORIZONTAL_DIRECTIONS.Contains(directionFromInput) && HORIZONTAL_DIRECTIONS.Contains(currentDirection)) ||
                (VERTICAL_DIRECTIONS.Contains(directionFromInput) && VERTICAL_DIRECTIONS.Contains(currentDirection)) ||
                directionChangeGateAllowedDirections.Contains(directionFromInput))
            {
                Debug.Log("Updating direction to: " + directionFromInput);
                currentDirection = directionFromInput;
                rb.velocity = Vector3.zero;
                RotatePacman();

                return;
            }

            pendingDirection = directionFromInput;
        }

        private void RotatePacman()
        {
            Quaternion pacmanDirection = transform.rotation;
            switch (currentDirection)
            {
                case Direction.LEFT:
                    {
                        pacmanDirection = Quaternion.AngleAxis(HORIZONTAL_ROTATION, Vector3.up);

                        break;
                    }
                case Direction.RIGHT:
                    {
                        pacmanDirection = Quaternion.AngleAxis(-HORIZONTAL_ROTATION, Vector3.up);

                        break;
                    }
                case Direction.FORWARD:
                    {
                        pacmanDirection = Quaternion.AngleAxis(VERTICAL_ROTATION, Vector3.up);

                        break;
                    }
                case Direction.BACKWARD:
                    {
                        pacmanDirection = Quaternion.AngleAxis(0f, Vector3.up);

                        break;
                    }
            }
            transform.rotation = pacmanDirection;
        }

        private void MovePacman()
        {
            Debug.Log("Move pacman: " + currentDirection);
            Vector3 forceVector = Vector3.zero;
            switch(currentDirection)
            {
                case Direction.LEFT:
                    {
                        forceVector = Vector3.left;

                        break;
                    }
                case Direction.RIGHT:
                    {
                        forceVector = Vector3.right;

                        break;
                    }
                case Direction.FORWARD:
                    {
                        forceVector = Vector3.forward;

                        break;
                    }
                case Direction.BACKWARD:
                    {
                        forceVector = Vector3.back;

                        break;
                    }
            }

            if (forceVector == Vector3.zero) return;

            rb.AddForce(forceVector * movementSpeed, ForceMode.VelocityChange);
        }
    }
}