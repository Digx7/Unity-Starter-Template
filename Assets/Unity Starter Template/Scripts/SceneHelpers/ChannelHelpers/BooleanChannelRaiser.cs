using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class BooleanChannelRaiser : MonoBehaviour
    {
        [SerializeField] private BooleanChannel channelToRaise;
        [SerializeField] private bool m_data;

        public void Raise(bool data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(m_data);
        }
    }
}
