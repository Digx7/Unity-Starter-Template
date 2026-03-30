using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class ChannelListener : MonoBehaviour 
    {
        [SerializeField] private Channel channelToListenTo;

        public UnityEvent onChannelRaised;

        private void OnEnable()
        {
            channelToListenTo.channelEvent.AddListener(OnHearChannel);
        }

        private void OnDisable()
        {
            channelToListenTo.channelEvent.RemoveListener(OnHearChannel);
        }

        public void OnHearChannel()
        {
            SendOutResponse();
        }

        public void SendOutResponse()
        {
            onChannelRaised.Invoke();
        }
    }
}