using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class StringAndGameObjectChannelRaiser : MonoBehaviour
    {
        [SerializeField] private StringAndGameObjectChannel channelToRaise;
        [SerializeField] private StringAndGameObject _data;

        public void Raise(StringAndGameObject data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(_data);
        }
    }
}
