using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    #region Private Vars
    private float moveAmount;
    #endregion

    #region Public Vars
    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;
    #endregion

    #region References
    PlayerControls playerControls;
    [SerializeField] AnimatorHandler animHandler;
    #endregion

    #region Public Functions
    public void HandleAllInputs()
    {
        HandleMovementInput();
    }
    #endregion
    #region Private Functions
    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animHandler.UpdateAnimatorValues(0, moveAmount);
    }
    #endregion

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.Player.Move.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.Player.Move.canceled += i => movementInput = new Vector2(0f,0f);
        }

        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
}
