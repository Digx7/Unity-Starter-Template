using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class UIWidgetDataChannelRaiser : MonoBehaviour
    {
        [SerializeField] private UIWidgetDataChannel channelToRaise;
        [SerializeField] private UIWidgetData m_data;

        public void Raise(UIWidgetData data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(m_data);
        }
    }
}
