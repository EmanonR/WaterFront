using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [Header("Main")]
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public TMP_Text nameText;

    [Header("Choises")]
    public GameObject choicePrefab;
    public GameObject choiceParent;

    List<GameObject> choiceList;

    private void Awake()
    {
        DialogueManager.NewLine += UpdateDialogue;
        DialogueManager.NewName += UpdateName;
    }

    private void OnDestroy()
    {
        DialogueManager.NewLine -= UpdateDialogue;
        DialogueManager.NewName -= UpdateName;
    }

    void UpdateDialogue(string line)
    {
        dialogueText.text = line;
    }

    void UpdateName(string name)
    {
        nameText.text = name;
    }

    //replace string (most likely)
    void DisplayChoices(List<string> choices)
    {
        foreach (var obj in choiceList)
        {
            Destroy(obj);
        }

        choiceList.Clear();

        foreach (var choice in choices)
        {
            GameObject obj = Instantiate(choicePrefab, choiceParent.transform);
            obj.GetComponent<DialogueOption>().SetText(choice);
            choiceList.Add(obj);
        }
    }
}
