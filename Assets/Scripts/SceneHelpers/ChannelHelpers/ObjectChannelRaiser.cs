using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class ObjectChannelRaiser : MonoBehaviour
    {
        [SerializeField] private ObjectChannel channelToRaise;
        [SerializeField] private Object m_data;

        public void Raise(Object data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(m_data);
        }
    }
}
