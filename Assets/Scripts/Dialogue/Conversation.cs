using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")] 
public class Conversation : ScriptableObject
{
    public List<Dialogue> Dialogue = new();
}

[System.Serializable]
public class Dialogue
{
    public string speakerName;
    [TextArea(2,5)]
    public List<string> dialogue = new();
}
