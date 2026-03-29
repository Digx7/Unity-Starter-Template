using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class Vector2ChannelRaiser : MonoBehaviour
    {
        [SerializeField] private Vector2Channel channelToRaise;
        [SerializeField] private Vector2 m_data;

        public void Raise(Vector2 data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(m_data);
        }
    }
}
