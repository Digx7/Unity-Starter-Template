using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class ShortChannelRaiser : MonoBehaviour
    {
        [SerializeField] private ShortChannel channelToRaise;
        [SerializeField] private short m_data;

        public void Raise(short data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(m_data);
        }
    }
}
