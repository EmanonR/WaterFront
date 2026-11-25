using TMPro;
using UnityEngine;

public class DialogueOption : MonoBehaviour
{
    public TMP_Text choiceText;

    public void SetText(string text)
    {
        choiceText.text = text;
    }
}
