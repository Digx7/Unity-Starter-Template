using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class StringAndGameObjectChannelListener : MonoBehaviour 
    {
        [SerializeField] private StringAndGameObjectChannel channelToListenTo;

        public StringAndGameObjectEvent onChannelRaised;

        public bool checkLastValueOnStart;
        public bool shouldFilterValue = false;
        public bool shouldPassHeardDataThrough = true;

        public StringAndGameObject filter;
        public StringAndGameObject outgoingDataIfNotPassHeardDataThrough;

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

        public void OnHearChannel(StringAndGameObject data)
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

        public void SendOutResponse(StringAndGameObject incomingData)
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