using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class IntChannelRaiser : MonoBehaviour
    {
        [SerializeField] private IntChannel channelToRaise;
        [SerializeField] private int m_data;

        public void Raise(int data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(m_data);
        }
    }
}
