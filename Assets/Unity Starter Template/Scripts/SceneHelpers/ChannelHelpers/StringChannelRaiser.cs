using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class StringChannelRaiser : MonoBehaviour
    {
        [SerializeField] private StringChannel channelToRaise;
        [SerializeField] private string m_data;

        public void Raise(string data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(m_data);
        }
    }
}
