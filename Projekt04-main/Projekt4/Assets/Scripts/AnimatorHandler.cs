using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{
    [SerializeField] Animator playerAnim;
    int horizontal;
    int vertical;

    private void Awake()
    {
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    public void UpdateAnimatorValues(float horizontalMovement,float verticalMovement,bool isSprinting)
    {
        //Animation Snapping, so there is no blending between animations/rounding values 
        float snappedHorizontal;
        float snappedVertical;
        #region Snapped Horizontal
        if (horizontalMovement > 0 && horizontalMovement < 0.55f)
        {
            snappedHorizontal = 0.5f;
        }
        else if (horizontalMovement > 0.55f)
        {
            snappedHorizontal = 1f;
        }
        else if (horizontalMovement < 0 && horizontalMovement > -0.55f)
        {
            snappedHorizontal = -0.5f;
        }
        else if (horizontalMovement < -0.55f)
        {
            snappedHorizontal = -1f;
        }
        else
        {
            snappedHorizontal = 0;
        }
        #endregion
        #region Snapped Vertical
        if (verticalMovement > 0 && verticalMovement < 0.55f)
        {
            snappedVertical = 0.5f;
        }
        else if (verticalMovement > 0.55f)
        {
            snappedVertical = 1f;
        }
        else if (verticalMovement < 0 && verticalMovement > -0.55f)
        {
            snappedVertical = -0.5f;
        }
        else if (verticalMovement < -0.55f)
        {
            snappedVertical = -1f;
        }
        else
        {
            snappedVertical = 0;
        }
        #endregion

        if (isSprinting)
        {
            snappedHorizontal = horizontalMovement;
            snappedVertical = 2f;
        }

        playerAnim.SetFloat(horizontal, snappedHorizontal,0.1f, Time.deltaTime);
        playerAnim.SetFloat(vertical, snappedVertical, 0.1f, Time.deltaTime);
    }

}
