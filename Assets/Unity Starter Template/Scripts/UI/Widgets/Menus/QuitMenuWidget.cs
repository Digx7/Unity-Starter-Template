using UnityEngine;

namespace Digx7.Zygote
{
    public class QuitMenuWidget : UIMenu
    {
        #region Variables ================================

        [SerializeField] UIWidgetData mainMenuWidgetData;
        
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

        public void OnClickNo()
        {
            requestLoadUIWidgetChannel.Raise(mainMenuWidgetData);
            requestUnLoadUIWidgetChannel.Raise(ownUIWidgetData);
        }

        public void OnClickYes()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }

        #endregion
    }
}
