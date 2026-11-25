using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")] 
public class Conversation : ScriptableObject
{
    List<Dialogue> Dialogue = new();
}

public class Dialogue
{
    string speakerName;
    List<string> dialogue = new();
}
