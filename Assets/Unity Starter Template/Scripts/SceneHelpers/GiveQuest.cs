using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

namespace Digx7.Zygote
{
    public class GiveQuest : MonoBehaviour
    {
        public QuestData quest;
        public QuestDataChannel giveQuestChannel;

        public void GiveNewQuest()
        {
            giveQuestChannel.Raise(quest);
        }
    }
}