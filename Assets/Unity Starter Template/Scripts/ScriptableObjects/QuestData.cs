using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewQuestData", menuName = "ScriptableObjects/Quest/Data", order = 1)]
public class QuestData : ScriptableObject
{
    public string questName;

    [TextArea]
    public string questDescription;
    public string questCompleteResult;
    [SerializeField] private List<QuestNode> nodes;

    private int activeNodeIndex = 0;

    public void ResetQuest()
    {
        Debug.Log("QuestData: ResetQuest()");
        for (int i = 0; i < nodes.Count; i++)
        {
            nodes[i].Reset();
        }

        activeNodeIndex = 0;
    }

    public bool IsComplete()
    {
        if(activeNodeIndex >= nodes.Count) return true;
        else return false;
    }

    public bool TryProgress(QuestObjectiveProgress progress)
    {
        if(activeNodeIndex >= nodes.Count) return false;

        if(nodes[activeNodeIndex].TryProgress(progress))
        {
            if(nodes[activeNodeIndex].AllObjectivesMet()) activeNodeIndex++;
            else
            {
                Debug.Log("QuestData: Progressed objective but not all objectives are met");
            }
            return true;
        }
        return false;
    }

    public void Finish()
    {
        // Todo
    }

    public string ToString()
    {
        return questName;
    }
}

[System.Serializable]
public struct QuestNode
{
    public string nodeName;
    public List<QuestObjective> objectives;
    public List<QuestNodeOutcome> outcomes;

    public bool AllObjectivesMet()
    {
        for (int i = 0; i < objectives.Count; i++)
        {
            if(objectives[i].passed == false)
            {
                Debug.Log("QuestNode: objective " + objectives[i].objectiveName + " : " + objectives[i].passed);
                return false;
            }
        }

        Debug.Log("QuestNode: Met all objectives for the node: " + nodeName);

        return true;
    }

    public void Reset()
    {
        for (int i = 0; i < objectives.Count; i++)
        {
            objectives[i].Reset();
        }
    }

    public bool TryProgress(QuestObjectiveProgress progress)
    {
        for (int i = 0; i < objectives.Count; i++)
        {
            if(objectives[i].TryProgress(progress)) return true;
        }
        return false;
    }

}

[System.Serializable]
public struct QuestObjective
{
    public string objectiveName;
    public QuestObjectiveType objectiveType;
    public int goalAmount;
    public string data;

    public bool passed;
    private int progressAmount;
    public bool TryProgress(QuestObjectiveProgress progress)
    {
        if(progress.objectiveName != objectiveName) return false;

        Debug.Log("QuestObjective: progressed objective: " + objectiveName);

        progressAmount += progress.addedAmount;

        switch (objectiveType)
        {
            case QuestObjectiveType.Kill_x:
                if(HasMetXGoal()) passed = true;
                break;
            case QuestObjectiveType.Deliver_x_items:
                if(HasMetXGoal()) passed = true;
                break;
            default:
                Debug.Log("QuestObjective: default case");
                passed = true;
                break;
        }

        Debug.Log("QuestObjective: " + objectiveName + " : " + passed);

        return true;
    }

    private bool HasMetXGoal()
    {
        if(progressAmount >= goalAmount) return true;
        else return false;
    }

    public void Reset()
    {
        passed = false;
        progressAmount = 0;
    }

}

public enum QuestObjectiveType {Talk_To_x, Interact_With_x,Kill_x, Deliver_x_items, Go_to_x}

[System.Serializable]
public struct QuestNodeOutcome
{
    public QuestNodeOutcomeType outcomeType;
    public string data;
}

public enum QuestNodeOutcomeType {Give_item, Apply_Status}

[System.Serializable]
public struct QuestObjectiveProgress
{
    public string objectiveName;
    public int addedAmount;
}

public class QuestObjectiveProgressEvent : UnityEvent<QuestObjectiveProgress> {}

public class QuestDataEvent : UnityEvent<QuestData> {}