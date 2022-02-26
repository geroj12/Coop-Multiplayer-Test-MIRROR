using UnityEngine;

namespace Projekt04
{
    public class Player : MonoBehaviour
    {

        #region References
        [SerializeField]InputController inputController;
        [SerializeField]PlayerLocomotion playerLocomotion;
        #endregion

        #region Updates
        private void Update()
        {
            inputController.HandleAllInputs();
        }

        private void FixedUpdate()
        {
            playerLocomotion.HandleAllMovement();

        }
        #endregion
    }
}
