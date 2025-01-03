using UnityEngine;

public class MainMenu : GameMode
{
    [SerializeField] private UIWidgetDataChannel requestLoadUIWidgetChannel;
    [SerializeField] private Channel requestClearAllUIWidgetChannel;
    [SerializeField] private UIWidgetData mainMenuWidgetData;
    public override void Setup()
    {
        // add code here
        requestClearAllUIWidgetChannel.Raise();
        requestLoadUIWidgetChannel.Raise(mainMenuWidgetData);
        base.Setup();
    }

    public override void Teardown()
    {
        // add code here
        
        base.Teardown();
    }

    protected override void OnOptionsMenuQuit()
    {
        requestLoadUIWidgetChannel.Raise(mainMenuWidgetData);
    }
}