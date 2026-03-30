using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class ScriptableObjectChannelRaiser : MonoBehaviour
    {
        [SerializeField] private ScriptableObjectChannel channelToRaise;
        [SerializeField] private ScriptableObject m_data;

        public void Raise(ScriptableObject data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(m_data);
        }
    }
}
