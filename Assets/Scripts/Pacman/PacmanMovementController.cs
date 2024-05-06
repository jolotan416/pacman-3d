using Movement;
using UnityEngine;
using Utils;

namespace Pacman
{
    public class PacmanMovementController : MovementController
    {
        public PacmanMovementController(): base("PacmanMovementController")
        {

        }

        private void Update()
        {
            Direction directionFromInput = GetDirectionFromInputs(
                Input.GetAxis(Constants.HORIZONTAL_AXIS),
                Input.GetAxis(Constants.VERTICAL_AXIS));

            UpdateDirection(directionFromInput);
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
    }
}