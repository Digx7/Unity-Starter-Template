using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class SongDataChannelRaiser : MonoBehaviour
    {
        [SerializeField] private SongDataChannel channelToRaise;
        [SerializeField] private SongData m_data;

        public void Raise(SongData data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(m_data);
        }
    }
}
