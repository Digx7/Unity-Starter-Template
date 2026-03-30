using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class ChannelRaiser : MonoBehaviour
    {
        [SerializeField] private Channel channelToRaise;

        public void Raise()
        {
            channelToRaise.Raise();
        }
    }
}
