using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class GameMode : MonoBehaviour
    {
        #region Variables
        [Header("Variables")]
        public bool spawnPlayerOnSetup = true;
        public GameObject playerCharacterPreFab;
        public GameObject playerControllerPreFab;
        public GameObject cameraManagerPreFab;
        
        [Header("Incoming Channels")]
        [SerializeField] private Channel _request_GameModeTearDown_Channel;
        [SerializeField] private Channel _on_GameModeTearDownFinsished_Channel;
        [SerializeField] private Channel _on_GameModeSetupFinished_Channel;
        [SerializeField] private PlayerSpawnInfoChannel _request_SpawnPlayer_Channel;
        [SerializeField] private IntChannel _on_PlayerCharacterFinishedSetup_Channel;
        [SerializeField] private IntChannel _on_PlayerControllerFinishedSetup_Channel;
        [SerializeField] private Channel _on_OptionsMenuQuit_Channel;

        // [Header("Outgoing Events")]

        private PlayerSpawnInfo _playerSpawnInfo;
        private PlayerCharacter _playerCharacterBeingSetup;
        private PlayerController _playerControllerBeingSetup;
        private CameraManager _cameraManagerBeingSetup;

        #endregion

        // CHANNELS =================================

        #region Setup

        public virtual void Setup()
        {
            SetupChannels();
            if(spawnPlayerOnSetup) TryToFindPlayerSpawnHelper();
            
            DontDestroyOnLoad(this);
            _on_GameModeSetupFinished_Channel.Raise();
        }

        public virtual void Teardown()
        {
            TearDownChannels();
            _on_GameModeTearDownFinsished_Channel.Raise();
            Destroy(this.gameObject);
        }

         protected virtual void SetupChannels()
        {
            _request_GameModeTearDown_Channel.channelEvent.AddListener(OnRecieve_RequestGameModeTearDown);
            _request_SpawnPlayer_Channel.channelEvent.AddListener(OnRecieve_RequestSpanPlayer);
            _on_PlayerCharacterFinishedSetup_Channel.channelEvent.AddListener(OnRecieve_OnPlayerCharacterFinishedSetup);
            _on_PlayerControllerFinishedSetup_Channel.channelEvent.AddListener(OnRecieve_OnPlayerControllerFinishedSetup);
            _on_OptionsMenuQuit_Channel.channelEvent.AddListener(OnRecieve_OnOptionsMenuQuit);
        }

        protected virtual void TearDownChannels()
        {
            _request_GameModeTearDown_Channel.channelEvent.RemoveListener(OnRecieve_RequestGameModeTearDown);
            _request_SpawnPlayer_Channel.channelEvent.RemoveListener(OnRecieve_RequestSpanPlayer);
            _on_PlayerCharacterFinishedSetup_Channel.channelEvent.RemoveListener(OnRecieve_OnPlayerCharacterFinishedSetup);
            _on_PlayerControllerFinishedSetup_Channel.channelEvent.RemoveListener(OnRecieve_OnPlayerControllerFinishedSetup);
            _on_OptionsMenuQuit_Channel.channelEvent.RemoveListener(OnRecieve_OnOptionsMenuQuit);
        }

        #endregion

        #region Channel Responses
            protected void OnRecieve_RequestGameModeTearDown( )
            {
                Teardown();
            }

            protected void OnRecieve_RequestSpanPlayer(PlayerSpawnInfo newPlayerSpawnInfo )
            {
                SpawnPlayerCharacter(newPlayerSpawnInfo);
            }

            
            protected virtual void OnRecieve_OnPlayerCharacterFinishedSetup(int playerId)
            {
                SpawnPlayerController();
            }

            protected virtual void OnRecieve_OnPlayerControllerFinishedSetup(int playerId)
            {
                SpawnCameraManager();
            }

            protected virtual void OnRecieve_OnOptionsMenuQuit()
            {}

        #endregion

        // SPAWN PLAYER ================================================

        #region Main Functions

        protected virtual void TryToFindPlayerSpawnHelper()
        {
            // We are making us of the SceneSetupManagers
            // PlayerSpawnHelper playerSpawnHelper = FindFirstObjectByType<PlayerSpawnHelper>();
            // if(playerSpawnHelper != null) playerSpawnHelper.SpawnPlayer();
        }

        protected virtual void SpawnPlayerCharacter(PlayerSpawnInfo newPlayerSpawnInfo)
        {
            Debug.Log("GameMode: SpawnPlayerCharacter()");

            _playerSpawnInfo = newPlayerSpawnInfo;
            
            GameObject characterObj = Instantiate(playerCharacterPreFab, _playerSpawnInfo.location, _playerSpawnInfo.rotation);
            playerCharacterBeingSetup = characterObj.GetComponent<PlayerCharacter>();
            if(playerCharacterBeingSetup == null) return;

            playerCharacterBeingSetup.Setup(_playerSpawnInfo.ID);
        }

        protected virtual void SpawnPlayerController()
        {
            Debug.Log("GameMode: SpawnPlayerController()");
            
            GameObject controllerObj = Instantiate(playerControllerPreFab, _playerSpawnInfo.location, _playerSpawnInfo.rotation);
            playerControllerBeingSetup = controllerObj.GetComponent<PlayerController>();
            if(playerControllerBeingSetup == null) return;

            playerControllerBeingSetup.Setup(_playerSpawnInfo.ID, playerCharacterBeingSetup);
        }

        protected virtual void SpawnCameraManager()
        {
            Debug.Log("GameMode: SpawnCameraManager()");
            
            GameObject cameraObj = Instantiate(cameraManagerPreFab, _playerSpawnInfo.location, _playerSpawnInfo.rotation);
            cameraManagerBeingSetup = cameraObj.GetComponent<CameraManager>();
            if(cameraManagerBeingSetup == null) return;

            cameraManagerBeingSetup.Setup(_playerSpawnInfo.ID, playerControllerBeingSetup, playerCharacterBeingSetup);
        }


        #endregion

    }

}
