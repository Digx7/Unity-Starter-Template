using UnityEngine;

public class UIWidget : MonoBehaviour
{
    
    public virtual void Setup()
    {

    }

    public virtual void Teardown()
    {
        Destroy(this.gameObject);
    }
}
