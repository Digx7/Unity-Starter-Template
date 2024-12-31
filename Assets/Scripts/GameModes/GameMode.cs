using UnityEngine;

public class GameMode : MonoBehaviour
{
    public GameObject playerCharacter;
    public GameObject playerController;
    public GameObject cameraManager;
    
    [SerializeField] Channel gameModeTearDownChannel;
    [SerializeField] Channel onGameModeTearDownFinsishedChannel;
    [SerializeField] Channel onGameModeSetupFinishedChannel;

    // CHANNELS =================================

    private void OnEnable()
    {
        SetupChannels();
    }

    private void OnDisable()
    {
        TearDownChannels();
    }

    protected void SetupChannels()
    {
        gameModeTearDownChannel.channelEvent.AddListener(Teardown);
    }

    protected void TearDownChannels()
    {
        gameModeTearDownChannel.channelEvent.RemoveListener(Teardown);
    }

    // MAIN FUNCTIONS =================================

    public virtual void Setup()
    {
        DontDestroyOnLoad(this);
        onGameModeSetupFinishedChannel.Raise();
    }

    public virtual void Teardown()
    {
        onGameModeTearDownFinsishedChannel.Raise();
        Destroy(this.gameObject);
    }
}
