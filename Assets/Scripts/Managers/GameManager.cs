using UnityEngine;
using System;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] List<StringAndGameObject> allGameModes;
    [SerializeField] StringAndGameObject nextGameModeToLoad;
    private GameMode activeGameMode;

    // [Header: "Channels"]
    [SerializeField] Channel onSaveLoadedChannel;
    [SerializeField] StringChannel requestChangeGameModeChannel;
    [SerializeField] Channel onGameModeTeardownFinishedChannel;
    [SerializeField] Channel onGameModeSetupFinishedChannel;
    [SerializeField] Channel requestGameModeTearDownChannel;

    // CHANELS =================================

    private void OnEnable()
    {
        SetupChannels();
    }

    private void OnDisable()
    {
        TearDownChannels();
    }

    private void SetupChannels()
    {
        onSaveLoadedChannel.channelEvent.AddListener(OnSaveLoaded);
        requestChangeGameModeChannel.channelEvent.AddListener(RequestChangeGameMode);
        onGameModeTeardownFinishedChannel.channelEvent.AddListener(OnGameModeTeardownFinished);
        onGameModeSetupFinishedChannel.channelEvent.AddListener(OnGameModeSetupFinished);
    }

    private void TearDownChannels()
    {
        onSaveLoadedChannel.channelEvent.RemoveListener(OnSaveLoaded);
        requestChangeGameModeChannel.channelEvent.RemoveListener(RequestChangeGameMode);
        onGameModeTeardownFinishedChannel.channelEvent.RemoveListener(OnGameModeTeardownFinished);
        onGameModeSetupFinishedChannel.channelEvent.RemoveListener(OnGameModeSetupFinished);
    }

    // CHANNEL RESPONES =================================

    private void OnSaveLoaded()
    {}

    private void RequestChangeGameMode(string newGameMode)
    {
        // Checks that we are not loading the active gamemode
        if(newGameMode == nextGameModeToLoad.name)
        {
            Debug.LogWarning("Something just tried to change the gamemode to the currently active gamemode");
            return;
        }

        // Checks the requested gamemode is valide
        if(allGameModes.Exists(x => x.name == newGameMode))
        {
            nextGameModeToLoad = allGameModes.Find(x => x.name == newGameMode);


            // Checks if there is an active gamemode
            if(activeGameMode != null)
            {
                // Tearsdown the currently active GameMode, once that is done it GameManager will setup the new GameMode
                requestGameModeTearDownChannel.Raise();
                return;
            }
            else
            {
                // Jumps straight to loading the new gamemode
                OnGameModeTeardownFinished();
            }
            
        }
        else
        {
            Debug.LogWarning("Something tried to load the gamemode " + newGameMode + " which does not exist on the current GameManager.  Double check your spelling");
        }
    }

    private void OnGameModeTeardownFinished()
    {
        // Passing in nextGameModeToLoad as a prefab but it becomes a scene object
        LoadGameMode(nextGameModeToLoad.obj);
        SetupGameMode(activeGameMode);
    } 

    private void OnGameModeSetupFinished()
    {}

    // MAIN FUNCTIONS =================================

    public void LoadGameMode(GameObject newGameMode)
    {
        nextGameModeToLoad.obj = Instantiate(newGameMode);
        activeGameMode = nextGameModeToLoad.obj.GetComponent<GameMode>();
    }

    public void SetupGameMode(GameMode gameModeToSetup)
    {
        gameModeToSetup.Setup();
    }

}
