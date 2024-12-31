using UnityEngine;

public class TestingInput : MonoBehaviour
{
    
    [SerializeField] GameManager gameManager;
    [SerializeField] string gameModeToLoadOnStart;
    [SerializeField] StringChannel onChangeGameModeChannel;
    
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
    }
}