using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> activeQuests;
    public List<Quest> finishedQuests;

    public void AddQuest(Quest aQuest)
    {
        activeQuests.Add(aQuest);
    }

    public void RemoveQuest(Quest aQuest)
    {
        activeQuests.Remove(aQuest);
    }

    public void CompleteQuest(Quest aQuest)
    {
        activeQuests.Remove(aQuest);
        finishedQuests.Add(aQuest);
    }
}
