using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace Digx7.Zygote
{
    [CreateAssetMenu(fileName = "NewBooleanChannel", menuName = "ScriptableObjects/Channels/Boolean", order = 1)]
    public class BooleanChannel : ScriptableObject
    {

        public bool debug = true;
        public BooleanEvent channelEvent = new BooleanEvent();
    
        public bool lastValue { get; private set; }
    
        private void OnEnable()
        {
            ResetLastValue();
        }
    
        public void ResetLastValue()
        {
            lastValue = false;
        }

        public void Raise(bool value)
        {
            if (debug) Debug.Log("Raised Channel: " + this.name + " with value " + value);
        
            lastValue = value;
            channelEvent.Invoke(value);
        }    
    }
}