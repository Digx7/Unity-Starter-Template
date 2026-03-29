using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class MainMenu : GameMode
    {
        #region Variables
        
        [Header("Variables")]
        [SerializeField] private UIWidgetData mainMenuWidgetData;
        [SerializeField] private UIWidgetData splashScreenWidgetData;

        [Header("Incoming Channels")]
        [SerializeField] private UIWidgetDataChannel _request_LoadUIWidget_Channel;
        [SerializeField] private Channel _request_ClearAllUIWidget_Channel;
        
        // [Header("Outgoing Events")]

        #endregion

        #region Setup
        public override void Setup()
        {
            // add code here
            _request_ClearAllUIWidget_Channel.Raise();
            _request_LoadUIWidget_Channel.Raise(splashScreenWidgetData);
            base.Setup();
        }

        public override void Teardown()
        {
            // add code here
            
            base.Teardown();
        }

        #endregion

        #region Channel Responses

        protected override void OnRecieve_OnOptionsMenuQuit()
        {
            _request_LoadUIWidget_Channel.Raise(mainMenuWidgetData);
        }
        #endregion
        

    }
}