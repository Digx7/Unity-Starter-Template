using UnityEngine;

public class PlayerCharacter : Character
{
    [SerializeField] private IntChannel OnPlayerCharacterFinishedSetup;
    [SerializeField] private CameraManager cameraManager;

    public bool ConnectCameraManager(CameraManager newCameraManager)
    {
        if(!IsCameraManagerValid(newCameraManager)) return false;

        if(newCameraManager == cameraManager) return true;
        
        if(cameraManager != null)
        {
            Debug.LogWarning("The CameraManager: " + newCameraManager + " tried to connect to the PlayerCharacter " + this + " but it is already connected to the CameraManager: " + cameraManager + ".  If this was intentional use ForceConnectCameraManager instead");
            return false;
        }

        cameraManager = newCameraManager;
        return true;
    }

    public void ForceConnectCameraManager(CameraManager newCameraManager)
    {
        if(!IsCameraManagerValid(newCameraManager)) return;
        if(newCameraManager == cameraManager) return;
        
        cameraManager = newCameraManager;
    }

    private bool IsCameraManagerValid(CameraManager newCameraManager)
    {
        if(newCameraManager == null) return false;
        else return true;
    }

    public override void Setup(int newID = 0)
    {
        base.Setup(newID);

        OnPlayerCharacterFinishedSetup.Raise(ID);
    }
}