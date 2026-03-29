using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

namespace Digx7.Zygote
{
    public class ProgressQuestObjective : MonoBehaviour
    {
        public QuestObjectiveProgress quest;
        public QuestObjectiveProgressChannel giveQuestChannel;

        public void ProgressQuest()
        {
            giveQuestChannel.Raise(quest);
        }
    }
}