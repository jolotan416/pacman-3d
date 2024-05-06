using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Movement
{
    public abstract class MovementController : MonoBehaviour
    {
        private static readonly float VERTICAL_ROTATION = 180f;
        private static readonly float HORIZONTAL_ROTATION = 90f;
        private static List<Direction> HORIZONTAL_DIRECTIONS = new List<Direction>() { Direction.LEFT, Direction.RIGHT };
        private static List<Direction> VERTICAL_DIRECTIONS = new List<Direction>() { Direction.FORWARD, Direction.BACKWARD };

        [SerializeField]
        private float movementSpeed = 5f;

        private LogUtils logUtils;
        private Rigidbody rb;

        private Direction currentDirection = Direction.NONE;
        private Direction pendingDirection = Direction.NONE;

        private bool hasPassedGateEntry = false;
        private List<Direction> directionChangeGateAllowedDirections = HORIZONTAL_DIRECTIONS;

        public MovementController(string logTag)
        {
            logUtils = new LogUtils("PacmanMovementController");
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            MoveObject();
        }

        private void OnTriggerEnter(Collider other)
        {
            logUtils.LogDebug("OnTriggerEnter: " + other.tag);
            if (other.CompareTag(Constants.DIRECTION_CHANGE_ENTRY_TAG))
            {
                hasPassedGateEntry = false;
                if (HORIZONTAL_DIRECTIONS.Contains(currentDirection))
                {
                    directionChangeGateAllowedDirections = HORIZONTAL_DIRECTIONS;
                }
                else if (VERTICAL_DIRECTIONS.Contains(currentDirection))
                {
                    directionChangeGateAllowedDirections = VERTICAL_DIRECTIONS;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            logUtils.LogDebug("OnTriggerExit: " + other.tag);
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
                    RotateObject();
                }

                pendingDirection = Direction.NONE;
            }
        }

        protected List<Direction> GetAllowedDirections()
        {
            List<Direction> allowedDirections = directionChangeGateAllowedDirections;
            if (HORIZONTAL_DIRECTIONS.Contains(currentDirection))
            {
                foreach (Direction direction in HORIZONTAL_DIRECTIONS)
                {
                    allowedDirections.Add(direction);
                }
            }

            if (VERTICAL_DIRECTIONS.Contains(currentDirection))
            {
                foreach (Direction direction in VERTICAL_DIRECTIONS)
                {
                    allowedDirections.Add(direction);
                }
            }

            return allowedDirections;
        }

        protected void UpdateDirection(Direction updatedDirection)
        {
            pendingDirection = Direction.NONE;

            if (updatedDirection == Direction.NONE || currentDirection == updatedDirection) return;

            logUtils.LogDebug("Update direction => directionFromInput: " + updatedDirection +
                ", allowed directions: " + string.Join(", ", directionChangeGateAllowedDirections) +
                ", currentDirection: " + currentDirection);
            if ((HORIZONTAL_DIRECTIONS.Contains(updatedDirection) && HORIZONTAL_DIRECTIONS.Contains(currentDirection)) ||
                (VERTICAL_DIRECTIONS.Contains(updatedDirection) && VERTICAL_DIRECTIONS.Contains(currentDirection)) ||
                directionChangeGateAllowedDirections.Contains(updatedDirection))
            {
                logUtils.LogDebug("Updating direction to: " + updatedDirection);
                currentDirection = updatedDirection;
                rb.velocity = Vector3.zero;
                RotateObject();

                return;
            }

            pendingDirection = updatedDirection;
        }

        private void MoveObject()
        {
            logUtils.LogDebug("Move pacman: " + currentDirection);
            Vector3 forceVector = Vector3.zero;
            switch (currentDirection)
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

        private void RotateObject()
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
    }

}