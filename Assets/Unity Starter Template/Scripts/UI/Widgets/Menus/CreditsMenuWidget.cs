using UnityEngine;

namespace Digx7.Zygote
{
    public class CreditsMenuWidget : UIMenu
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

        public void OnClickBack()
        {
            requestLoadUIWidgetChannel.Raise(mainMenuWidgetData);
            requestUnLoadUIWidgetChannel.Raise(ownUIWidgetData);
        }

        #endregion
    }
}
