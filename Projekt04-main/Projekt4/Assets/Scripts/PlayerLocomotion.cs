using UnityEngine;
using Projekt04;

public class PlayerLocomotion : MonoBehaviour
{
    #region Private Vars
    Vector3 moveDirection;
    #endregion

    #region Bools
    public bool isSprinting;
    #endregion

    #region Public Vars
    [Header("MovementSpeeds")]
    [SerializeField] private float runningSpeed = 5f;
    [SerializeField] private float walkingSpeed = 1.5f;
    [SerializeField] private float sprintSpeed = 7f;
    [SerializeField] private float rotationSpeed = 15f;
    #endregion

    #region References
    [SerializeField] InputController inputController;
    [SerializeField] Transform cameraObject;
    [SerializeField] Rigidbody playerRigidbody;
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

        if (isSprinting==true)
        {
            moveDirection = moveDirection * sprintSpeed;
        }
        else
        {
            if (inputController.moveAmount >= 0.5f)
            {
                moveDirection = moveDirection * runningSpeed;
            }
            else
            {
                moveDirection = moveDirection * walkingSpeed;
            }
        }

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