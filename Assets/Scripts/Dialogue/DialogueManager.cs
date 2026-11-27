using System;
using UnityEngine;

public static class DialogueManager
{
    static int currentLine;
    static int currentDialogue;

    static Conversation currentConversation;

    public static event Action DialogueStart;
    public static event Action DialogueEnd;
    public static event Action<string> NewLine;
    public static event Action<string> NewName;

    public static void StartDialogue(Conversation conversation)
    {
        currentDialogue = 0;
        currentLine = 0;
        currentConversation = conversation;
        DialogueStart?.Invoke();
    }

    public static void AdvanceDialogue(Conversation aConversation)
    {
        //Start new dialogue if
        if (currentConversation == null || currentConversation != aConversation)
            StartDialogue(aConversation);

        //Next line in dialogue
        if (currentLine >= currentConversation.Dialogues[currentDialogue].lines.Count)
        {
            currentLine = 0;
            currentDialogue++;
        }
        else
        {
            currentLine++;
        }

        //End dialogue
        if (currentDialogue >= currentConversation.Dialogues.Count)
            EndDialogue();


        NewLine?.Invoke(currentConversation.Dialogues[currentDialogue].lines[currentLine]);
        NewName?.Invoke(currentConversation.Dialogues[currentDialogue].speakerName);
    }

    public static void EndDialogue()
    {
        currentDialogue = 0;
        currentLine = 0;
        currentConversation = null;
        DialogueEnd?.Invoke();
    }
}
