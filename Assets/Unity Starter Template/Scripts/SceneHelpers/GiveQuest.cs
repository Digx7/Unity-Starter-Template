using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

namespace Digx7.Zygote
{
    public class GiveQuest : MonoBehaviour
    {
        #region Variables ================================
        public QuestData quest;
        public QuestDataChannel giveQuestChannel;

        #endregion
        
        #region Main Functions ================================
        public void GiveNewQuest()
        {
            giveQuestChannel.Raise(quest);
        }
        #endregion
    }
}