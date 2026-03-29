using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class PlayerSpawnInfoChannelListener : MonoBehaviour 
    {
        [SerializeField] private PlayerSpawnInfoChannel channelToListenTo;

        public PlayerSpawnInfoEvent onChannelRaised;

        public bool checkLastValueOnStart;
        public bool shouldFilterValue = false;
        public bool shouldPassHeardDataThrough = true;

        public PlayerSpawnInfo filter;
        public PlayerSpawnInfo outgoingDataIfNotPassHeardDataThrough;

        private void Start()
        {
            if (checkLastValueOnStart) OnHearChannel(channelToListenTo.lastValue);
        }

        private void OnEnable()
        {
            channelToListenTo.channelEvent.AddListener(OnHearChannel);
        }

        private void OnDisable()
        {
            channelToListenTo.channelEvent.RemoveListener(OnHearChannel);
        }

        public void OnHearChannel(PlayerSpawnInfo data)
        {
            if(shouldFilterValue)
            {
                if(data == filter)
                {
                    SendOutResponse(data);
                }
            }
            else
            {
                SendOutResponse(data);
            }
        }

        public void SendOutResponse(PlayerSpawnInfo incomingData)
        {
            if(shouldPassHeardDataThrough) 
            {
                onChannelRaised.Invoke(incomingData);
            }
            else
            {
                onChannelRaised.Invoke(outgoingDataIfNotPassHeardDataThrough);
            }
        }
    }
}