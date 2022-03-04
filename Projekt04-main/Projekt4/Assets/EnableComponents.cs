using UnityEngine;
using Mirror;
using Cinemachine;
using Projekt04;

public class EnableComponents : NetworkBehaviour
{
    public Transform playerTransform;
    public Transform playerPivotTransform;

    [SerializeField]private GameObject mainVirtualCam;

    private void Start()
    {
        if (isLocalPlayer)
        {
            Player player = GetComponent<Player>();
            player.enabled = true;
            mainVirtualCam = GameObject.Find("Cinemachine/MainVirtualCam");
            CinemachineFreeLook cinemachineVirtualCamera = mainVirtualCam.GetComponent<CinemachineFreeLook>();
            cinemachineVirtualCamera.Follow = playerTransform;
            cinemachineVirtualCamera.LookAt = playerPivotTransform;
        }
    }

    
}
