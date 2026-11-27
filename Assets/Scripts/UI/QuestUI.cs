using TMPro;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public TMP_Text questText;
    public TMP_Text questSubtext;

    private void Awake()
    {
        //Subscribe to questmanager
        QuestManager.OnQuestAdded += UpdateText;
    }

    private void OnDestroy()
    {
        //Unsubscribe to questmanager
        QuestManager.OnQuestAdded -= UpdateText;
    }

    //Function should feed in a quest object
    void UpdateText(Quest aQuest)
    {
        if (questText != null)
            questText.text = aQuest.displayName;

        if (questSubtext != null)
            questSubtext.text = aQuest.description;
    }
}
