using System;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    int currentLine;
    int currentDialogue;

    Conversation currentConversation;

    public static event Action DialogueStart;
    public static event Action DialogueEnd;
    public static event Action<string> NewLine;
    public static event Action<string> NewName;

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
