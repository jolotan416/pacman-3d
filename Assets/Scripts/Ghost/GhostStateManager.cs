using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Food;
using Utils;

namespace Ghost
{
    public class GhostStateManager : MonoBehaviour
    {
        private static readonly int POWER_UP_DURATION = 5;

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
            StopAllCoroutines();
            StartCoroutine(StartPowerUpWithCountdown());
        }

        private IEnumerator StartPowerUpWithCountdown()
        {
            ToggleState(GhostState.NERFED, nerfedMaterial);

            yield return new WaitForSeconds(POWER_UP_DURATION);

            ToggleState(GhostState.BASE, ghostMaterial);
        }

        private void ToggleState(GhostState ghostState, Material ghostClothMaterial)
        {
            this.ghostState = ghostState;
            ghostClothRender.material = ghostClothMaterial;
            ghostFoodBehaviour.UpdateState(ghostState);
        }
    }

}