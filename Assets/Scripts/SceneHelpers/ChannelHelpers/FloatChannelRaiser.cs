using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class FloatChannelRaiser : MonoBehaviour
    {
        [SerializeField] private FloatChannel channelToRaise;
        [SerializeField] private float m_data;

        public void Raise(float data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(m_data);
        }
    }
}
