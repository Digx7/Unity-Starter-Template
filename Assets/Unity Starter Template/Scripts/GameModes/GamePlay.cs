using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class GamePlay : GameMode
    {
        #region Variables

        [Header("Variables")]
        [SerializeField] private UIWidgetData _pauseMenuWidgetData;
        
        [Header("Incoming Channels")]
        [SerializeField] private UIWidgetDataChannel _request_LoadUIWidget_Channel;
        [SerializeField] private Channel _request_LoadSaveData_Channel;

        // [Header("Outgoing Events")]

        #endregion

        #region Setup

        public override void Setup()
        {
            // add code here
            
            base.Setup();

            _request_LoadSaveData_Channel.Raise();
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
            _request_LoadUIWidget_Channel.Raise(pauseMenuWidgetData);
        }

        #endregion
    }
}