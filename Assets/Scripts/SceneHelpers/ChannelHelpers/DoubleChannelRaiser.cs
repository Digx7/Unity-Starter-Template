using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class DoubleChannelRaiser : MonoBehaviour
    {
        [SerializeField] private DoubleChannel channelToRaise;
        [SerializeField] private double m_data;

        public void Raise(double data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(m_data);
        }
    }
}
