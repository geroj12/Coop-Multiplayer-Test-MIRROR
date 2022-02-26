using UnityEngine;
using UnityEngine.InputSystem;
using Projekt04;

public class InputController : MonoBehaviour
{
    #region Public Vars
    [SerializeField]  private Vector2 movementInput;
    [HideInInspector] public float verticalInput;
    [HideInInspector] public float horizontalInput;
    [HideInInspector] public float moveAmount;
    #endregion

    #region References
    PlayerControls playerControls;
    [SerializeField] AnimatorHandler animHandler;
    [SerializeField] PlayerLocomotion playerLocomotion;
    #endregion

    public bool shiftInput;

    #region Public Functions
    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleSprintingInput();
    }
    #endregion
    #region Private Functions
    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animHandler.UpdateAnimatorValues(0, moveAmount,playerLocomotion.isSprinting);
    }

    private void HandleSprintingInput()
    {
        if (shiftInput == true && moveAmount > 0.5f)
        {
            playerLocomotion.isSprinting = true;
        }
        else
        {
            playerLocomotion.isSprinting = false;
        }
    }
    #endregion

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.Player.Move.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.Player.Move.canceled += i => movementInput = new Vector2(0f,0f);

            playerControls.Actions.Shift.performed += i => shiftInput = true;
            playerControls.Actions.Shift.canceled += i => shiftInput = false;
        }

        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
}
