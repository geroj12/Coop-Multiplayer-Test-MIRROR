using UnityEngine;
using UnityEngine.UI;

public class LockMouseCursor : MonoBehaviour
{

    [SerializeField] Toggle toggleMouseCursor;
  
    public void Lock()
    {
        bool Switch = toggleMouseCursor.isOn;
        if (Switch == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

   
}
