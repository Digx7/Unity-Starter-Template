using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class SceneDataChannelRaiser : MonoBehaviour
    {
        [SerializeField] private SceneDataChannel channelToRaise;
        [SerializeField] private SceneData _data;

        public void Raise(SceneData data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(_data);
        }
    }
}
