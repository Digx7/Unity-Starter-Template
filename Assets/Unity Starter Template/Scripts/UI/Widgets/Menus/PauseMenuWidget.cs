using UnityEngine;

namespace Digx7.Zygote
{
    public class PauseMenuWidget : UIMenu
    {
        #region Variables ================================
        
        [SerializeField] private SceneData mainMenuScene;
        [SerializeField] UIWidgetData optionsMenuWidgetData;

        [SerializeField] SceneDataChannel requestChangeSceneDataChannel;
        [SerializeField] UIWidgetDataChannel requestLoadUIWidgetChannel;
        [SerializeField] UIWidgetDataChannel requestUnLoadUIWidgetChannel;

        #endregion

        #region Setup ================================

        public override void Setup(UIWidgetData newUIWidgetData)
        {
            base.Setup(newUIWidgetData);
        }

        public override void Teardown()
        {
            base.Teardown();
        }

        #endregion

        #region Main Functions ================================

        public void OnClickResume()
        {
            requestUnLoadUIWidgetChannel.Raise(ownUIWidgetData);
        }

        public void OnClickOptions()
        {
            requestLoadUIWidgetChannel.Raise(optionsMenuWidgetData);
            requestUnLoadUIWidgetChannel.Raise(ownUIWidgetData);
        }

        public void OnClickQuit()
        {
            requestChangeSceneDataChannel.Raise(mainMenuScene);
            requestUnLoadUIWidgetChannel.Raise(ownUIWidgetData);
        }

        #endregion
    }
}
