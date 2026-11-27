using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> activeQuests;
    public List<Quest> finishedQuests;

    public static event Action<Quest> OnQuestCompleted; 
    public static event Action<Quest> OnQuestAdded; 

    public static QuestManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void AddQuest(Quest aQuest)
    {
        activeQuests.Add(aQuest);
        OnQuestAdded?.Invoke(aQuest);
    }

    public void RemoveQuest(Quest aQuest)
    {
        activeQuests.Remove(aQuest);
    }

    public void CompleteQuest(Quest aQuest)
    {
        activeQuests.Remove(aQuest);
        finishedQuests.Add(aQuest);
        OnQuestCompleted?.Invoke(aQuest);
    }
}
