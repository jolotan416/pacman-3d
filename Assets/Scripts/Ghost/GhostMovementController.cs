using System.Collections.Generic;
using UnityEngine;
using Movement;
using Utils;

namespace Ghost
{
    public class GhostMovementController : MovementController
    {
        [SerializeField]
        private GhostType ghostType = GhostType.FOLLOWER;

        private GhostMovementStrategy ghostMovementStrategy;
        private Transform pacmanTransform;
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

            InitializeGhostMovementStrategy();
            pacmanTransform = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG).transform;
        }

        override protected void OnAllowedDirectionsChange(List<Direction> allowedDirections)
        {
            logUtils.LogDebug("Allowed directions change: " + string.Join(", ", allowedDirections));
            CalculateNewDirection(allowedDirections);
        }

        private void InitializeGhostMovementStrategy()
        {
            switch (ghostType)
            {
                case GhostType.FOLLOWER:
                    {
                        ghostMovementStrategy = new FollowerGhostMovementStrategy();

                        break;
                    }

                case GhostType.RANDOM:
                    {
                        ghostMovementStrategy = new RandomGhostMovementStrategy();

                        break;
                    }
            }
            logUtils.LogDebug("Initialized with ghost movement strategy: " + ghostMovementStrategy);
        }

        private void CalculateNewDirection(List<Direction> allowedDirections)
        {
            Direction updatedDirection = ghostMovementStrategy.CalculateNewDirection(
                allowedDirections, transform.position, pacmanTransform.position);
            logUtils.LogDebug("Updated direction: " + updatedDirection);
            UpdateDirection(updatedDirection);
        }
    }

}