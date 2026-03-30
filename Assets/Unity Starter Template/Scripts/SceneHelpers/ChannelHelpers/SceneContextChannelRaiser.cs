using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class SceneContextChannelRaiser : MonoBehaviour
    {
        [SerializeField] private SceneContextChannel channelToRaise;
        [SerializeField] private SceneContext _data;

        public void Raise(SceneContext data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(_data);
        }
    }
}
