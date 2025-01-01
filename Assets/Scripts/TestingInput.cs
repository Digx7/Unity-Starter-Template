using UnityEngine;

public class TestingInput : MonoBehaviour
{
    [SerializeField] string gameModeToLoadOnStart;
    [SerializeField] StringChannel onChangeGameModeChannel;
    [SerializeField] StringChannel changeSceneChannel;
    
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            onChangeGameModeChannel.Raise(gameModeToLoadOnStart);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            onChangeGameModeChannel.Raise("MainMenu");
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            onChangeGameModeChannel.Raise("GamePlay");
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            changeSceneChannel.Raise("MainMenu");
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            changeSceneChannel.Raise("GamePlay");
        }
    }
}