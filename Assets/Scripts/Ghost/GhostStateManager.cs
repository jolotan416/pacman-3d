using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Food;
using Utils;

namespace Ghost
{
    public class GhostStateManager : MonoBehaviour
    {
        [SerializeField]
        private Material ghostMaterial;

        [SerializeField]
        private Material nerfedMaterial;

        [SerializeField]
        private Renderer ghostClothRender;

        private LogUtils logUtils = new LogUtils("GhostStateManager");
        private GhostState ghostState = GhostState.BASE;
        private GhostFoodBehaviour ghostFoodBehaviour;

        private void Start()
        {
            ghostFoodBehaviour = gameObject.GetComponent<GhostFoodBehaviour>();
        }

        public void PowerUp()
        {
            logUtils.LogDebug("Powering up...");

            ghostState = GhostState.NERFED ;
            ghostClothRender.material = nerfedMaterial;
            ghostFoodBehaviour.UpdateState(ghostState);
        }
    }

}