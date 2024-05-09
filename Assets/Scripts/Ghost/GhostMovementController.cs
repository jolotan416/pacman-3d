using System.Collections.Generic;
using UnityEngine;
using Movement;
using Utils;

namespace Ghost
{
    public class GhostMovementController : MovementController
    {
        private Transform pacmanPosition;
        private LogUtils logUtils = new LogUtils("GhostMovementController");

        public GhostMovementController(): 
            base(
                "GhostMovementController", 
                Direction.FORWARD,
                new List<Direction> { Direction.FORWARD })
        {

        }

        private new void Start()
        {
            base.Start();

            pacmanPosition = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG).transform;
        }

        override protected void OnAllowedDirectionsChange(List<Direction> allowedDirections)
        {
            logUtils.LogDebug("Allowed directions change: " + string.Join(", ", allowedDirections));
            CalculateNewDirection(allowedDirections);
        }

        private void CalculateNewDirection(List<Direction> allowedDirections)
        {
            float horizontalDistanceFromPacman = transform.position.x - pacmanPosition.position.x;
            Direction horizontalDirection = horizontalDistanceFromPacman > 0 ? Direction.LEFT : Direction.RIGHT;

            float verticalDistanceFromPacman = transform.position.z - pacmanPosition.position.z;
            Direction verticalDirection = verticalDistanceFromPacman > 0 ? Direction.BACKWARD : Direction.FORWARD;

            Direction updatedDirection = (allowedDirections.Contains(horizontalDirection)) ? horizontalDirection : 
                (allowedDirections.Contains(verticalDirection) ? verticalDirection : allowedDirections[0]);
            logUtils.LogDebug("Updated direction: " + updatedDirection);
            UpdateDirection(updatedDirection);
        }
    }

}