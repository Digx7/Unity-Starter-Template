using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class Vector3IntChannelRaiser : MonoBehaviour
    {
        [SerializeField] private Vector3IntChannel channelToRaise;
        [SerializeField] private Vector3Int m_data;

        public void Raise(Vector3Int data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(m_data);
        }
    }
}
