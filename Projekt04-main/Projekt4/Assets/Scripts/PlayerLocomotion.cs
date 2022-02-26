using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    #region Private Vars
    Vector3 moveDirection;
    #endregion

    #region Public Vars
    [SerializeField] private float movementSpeed = 7;
    [SerializeField] private float rotationSpeed = 15;
    #endregion

    #region References
    [SerializeField]InputController inputController;
    [SerializeField]Transform cameraObject;
    [SerializeField]Rigidbody playerRigidbody;
    #endregion

    #region Public Functions
    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }
    #endregion

    #region Private Functions
    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputController.verticalInput;
        moveDirection += cameraObject.right * inputController.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * movementSpeed;

        Vector3 movementVelocity = moveDirection;
        playerRigidbody.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * inputController.verticalInput;
        targetDirection += cameraObject.right * inputController.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }
    #endregion
}
