using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace Digx7.Zygote
{
    [System.Serializable]
    public struct ConversationNode
    {
        public string speaker;
        
        [TextAreaAttribute]
        public string line;

        public void Print()
        {
            Debug.Log(speaker + ":\n" + line);
        }
    }
}