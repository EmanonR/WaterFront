using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")] 
public class Conversation : ScriptableObject
{
    public List<Dialogue> Dialogues = new();
}

[System.Serializable]
public class Dialogue
{
    public string speakerName;
    [TextArea(2,5)]
    public List<string> lines = new();
}
