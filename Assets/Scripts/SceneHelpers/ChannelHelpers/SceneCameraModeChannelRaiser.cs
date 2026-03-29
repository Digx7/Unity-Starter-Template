using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class SceneCameraModeChannelRaiser : MonoBehaviour
    {
        [SerializeField] private SceneCameraModeChannel channelToRaise;
        [SerializeField] private SceneCameraMode _data;

        public void Raise(SceneCameraMode data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(_data);
        }
    }
}
