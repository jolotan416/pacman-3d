using System.Collections.Generic;
using UnityEngine;
using Movement;
using Utils;

namespace Ghost
{
    public class RandomGhostMovementStrategy : GhostMovementStrategy
    {
        private LogUtils logUtils = new LogUtils("RandomGhostMovementStrategy");

        public Direction CalculateNewDirection(List<Direction> allowedDirections,
           Vector3 ghostPosition, Vector3 playerPosition)
        {
            int randomNumber = Random.Range(0, 100);
            int randomIndex = randomNumber % allowedDirections.Count;
            logUtils.LogDebug("Selected index: " + randomIndex);

            return allowedDirections[randomIndex];
        }
    }
}