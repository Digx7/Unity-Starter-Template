using UnityEngine;

public class SceneSetupManager : MonoBehaviour
{
    [SerializeField] StringChannel onChangeGameModeChannel;
    [SerializeField] string gameModeToChangeToOnSetup;
    
    [SerializeField] bool triggerOnStart = true;

    public void Start()
    {
        if(triggerOnStart) Setup();
    }

    public void Setup()
    {
        onChangeGameModeChannel.Raise(gameModeToChangeToOnSetup);

        // Add code here
    }
}
