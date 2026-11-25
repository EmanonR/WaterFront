using TMPro;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public TMP_Text questText;
    public TMP_Text questSubtext;

    private void Awake()
    {
        //Subscribe to questmanager
        UpdateText();
    }

    private void OnDestroy()
    {
        //Unsubscribe to questmanager
    }

    //Function should feed in a quest object
    void UpdateText()
    {
        if (questText != null)
            questText.text = "Carps for Senpai";

        if (questSubtext != null)
            questSubtext.text = "Catch 2 carps";
    }
}
