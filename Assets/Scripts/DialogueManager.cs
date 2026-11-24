using System;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    int currentLine;
    int currentDialogue;

    Conversation currentConversation;

    public event Action<Dialogue> NewDialogue;
    public event Action<string> NewLine;

    public void StartDialogue(Conversation conversation)
    {
        currentConversation = conversation;
    }

    public void HandleDialogue()
    {
        currentDialogue++;
        currentLine++;
    }

    public void EndDialogue()
    {
        currentConversation = null;
    }
}
