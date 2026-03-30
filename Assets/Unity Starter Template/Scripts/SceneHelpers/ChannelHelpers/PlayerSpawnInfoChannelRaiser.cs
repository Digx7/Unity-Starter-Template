using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class PlayerSpawnInfoChannelRaiser : MonoBehaviour
    {
        [SerializeField] private PlayerSpawnInfoChannel channelToRaise;
        [SerializeField] private PlayerSpawnInfo _data;

        public void Raise(PlayerSpawnInfo data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(_data);
        }
    }
}
