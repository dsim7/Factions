using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueView : MonoBehaviour
{
    public DialogueObjectVariable currentDialogue;
    public BlackScreen blackScreen;

    public Text speakerName;
    public Text message;
    public Image image;

    Animator animator;

	void Start ()
    {
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        currentDialogue.RegisterAction(UpdateDialogue);
    }

    void OnDisable()
    {
        currentDialogue.UnregisterAction(UpdateDialogue);
    }
	
	void UpdateDialogue()
    {
        transform.parent.SetAsLastSibling();

        if (currentDialogue.Value == null)
        {
            animator.SetTrigger("Close");
            blackScreen.fadedIn = false;
            return;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Hidden"))
        {
            animator.SetTrigger("Open");
            blackScreen.fadedIn = true;
        }
        speakerName.text = currentDialogue.Value.speakerName;
        message.text = currentDialogue.Value.message;
        image.sprite = currentDialogue.Value.speakerPortrait;
    }
}
