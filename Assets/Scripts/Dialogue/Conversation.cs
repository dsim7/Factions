using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Conversation : ScriptableObject
{
    public DialogueObjectVariable currentDialogue;
    public List<Dialogue> dialogues = new List<Dialogue>();
    
    [SerializeField]
    int currentIndex = 0;

    public bool Next()
    {
        if (dialogues.Count == 0 || currentIndex == dialogues.Count)
        {
            currentDialogue.Value = null;
            Reset();
            return false;
        }
        currentDialogue.Value = dialogues[currentIndex++];
        return true;
    }

    public void Reset()
    {
        currentIndex = 0;
    }

}
