using UnityEngine;

public class PlayerController : GameController
{
    [SerializeField] protected CameraManager cameraManager;

    public bool ConnectCameraManager(CameraManager newCameraManager)
    {
        if(!IsCameraManagerValid(newCameraManager)) return false;

        if(newCameraManager == cameraManager) return true;
        
        if(cameraManager != null)
        {
            Debug.LogWarning("The CameraManager: " + newCameraManager + " tried to connect to the PlayerController " + this + " but it is already connected to the CameraManager: " + cameraManager + ".  If this was intentional use ForceConnectCameraManager instead");
            return false;
        }

        cameraManager = newCameraManager;
        cameraManager.SetID(ID);
        return true;
    }

    public void ForceConnectCameraManager(CameraManager newCameraManager)
    {
        if(!IsCameraManagerValid(newCameraManager))return;
        if(newCameraManager == cameraManager)return;

        cameraManager = newCameraManager;
        cameraManager.SetID(ID);
    }

    private bool IsCameraManagerValid(CameraManager newCameraManager)
    {
        if(newCameraManager == null) return false;
        else return true;
    }
}
