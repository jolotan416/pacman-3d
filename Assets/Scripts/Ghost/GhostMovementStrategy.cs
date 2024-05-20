using System.Collections.Generic;
using UnityEngine;
using Movement;

namespace Ghost
{
    public interface GhostMovementStrategy
    {
        public Direction CalculateNewDirection(List<Direction> allowedDirections, 
            Vector3 ghostPosition, Vector3 playerPosition);
    }
}