using System.Collections.Generic;
using UnityEngine;
using Movement;
using Utils;

namespace Ghost
{
    public class FollowerGhostMovementStrategy : GhostMovementStrategy
    {
        private LogUtils logUtils = new LogUtils("FollowerGhostMovementStrategy");

        public Direction CalculateNewDirection(List<Direction> allowedDirections,
           Vector3 ghostPosition, Vector3 playerPosition)
        {
            float horizontalDistanceFromPacman = ghostPosition.x - playerPosition.x;
            Direction horizontalDirection = horizontalDistanceFromPacman > 0 ? Direction.LEFT : Direction.RIGHT;

            float verticalDistanceFromPacman = ghostPosition.z - playerPosition.z;
            Direction verticalDirection = verticalDistanceFromPacman > 0 ? Direction.BACKWARD : Direction.FORWARD;

            Direction selectedDirection = (allowedDirections.Contains(horizontalDirection)) ? horizontalDirection :
                (allowedDirections.Contains(verticalDirection) ? verticalDirection : allowedDirections[0]);

            logUtils.LogDebug("Selected direction: " + selectedDirection);

            return selectedDirection;
        }
    }
}