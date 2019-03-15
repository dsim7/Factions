using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConversationManager : MonoBehaviour
{
    public DialogueObjectVariable currentDialogue;

    [SerializeField]
    Conversation _conversation;
    UnityAction _onComplete;

    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    public void StartConversation(Conversation conversation, UnityAction onComplete = null)
    {
        _conversation = conversation;
        _onComplete = onComplete;
        if (conversation != null)
        {
            conversation.Reset();
        }
        Next();
    }

    public void Next()
    {
        bool finished = !_conversation.Next();
        if (_conversation == null || finished)
        {
            if (_onComplete != null)
            {
                _onComplete();
            }
        }
    }
}
