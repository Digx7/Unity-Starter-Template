using UnityEngine;

public class UIWidget : MonoBehaviour
{
    
    protected UIWidgetData ownUIWidgetData;
    
    public virtual void Setup(UIWidgetData newUIWidgetData)
    {
        ownUIWidgetData = newUIWidgetData;
    }

    public virtual void Teardown()
    {
        Destroy(this.gameObject);
    }
}
