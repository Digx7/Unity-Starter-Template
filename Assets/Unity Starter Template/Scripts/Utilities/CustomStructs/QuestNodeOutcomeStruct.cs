using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace Digx7.Zygote
{
    [System.Serializable]
    public struct QuestNodeOutcome
    {
        public QuestNodeOutcomeType outcomeType;
        public string data;
    }
}