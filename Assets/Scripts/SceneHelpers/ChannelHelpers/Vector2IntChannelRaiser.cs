using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class Vector2IntChannelRaiser : MonoBehaviour
    {
        [SerializeField] private Vector2IntChannel channelToRaise;
        [SerializeField] private Vector2Int m_data;

        public void Raise(Vector2Int data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(m_data);
        }
    }
}
