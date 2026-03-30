using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

namespace Digx7.Zygote
{
    public class ProgressQuestObjective : MonoBehaviour
    {
        #region Variables ================================

        public QuestObjectiveProgress quest;
        public QuestObjectiveProgressChannel giveQuestChannel;

        #endregion

        #region Main Functions ================================
        public void ProgressQuest()
        {
            giveQuestChannel.Raise(quest);
        }
        #endregion
    }
}