using UnityEngine;
using System;
using System.Collections;

namespace Digx7.Zygote
{
    public class UIWidget : MonoBehaviour
    {
        #region Variables ================================
        
        protected UIWidgetData ownUIWidgetData;
        [SerializeField] private UIWidgetDataChannel RequestUnloadWidgetDataChannel;

        #endregion

        #region Setup ================================

        public virtual void Setup(UIWidgetData newUIWidgetData)
        {
            ownUIWidgetData = newUIWidgetData;
        }

        public virtual void Teardown()
        {
            Destroy(this.gameObject);
        }

        #endregion

        #region Main Functions ================================

        protected void UnloadSelf()
        {
            RequestUnloadWidgetDataChannel.Raise(ownUIWidgetData);
        }
        
        protected IEnumerator Delay(VoidDelegate funcToCalAtEnd, float time)
        {
            yield return new WaitForSeconds(time);
            funcToCalAtEnd();
        }

        protected IEnumerator Delay(IntDelegate funcToCalAtEnd, int value, float time)
        {
            yield return new WaitForSeconds(time);
            funcToCalAtEnd(value);
        }

        #endregion
    }
}
