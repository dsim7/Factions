using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorView : MonoBehaviour
{
    public StringVariable errorText;
    public BlackScreen blackScreen;
    public Text message;

    CanvasGroup cg;

	void Start ()
    {
        cg = GetComponent<CanvasGroup>();
        errorText.RegisterAction(UpdateText);
	}
	
	void UpdateText()
    {
        if (errorText.Value == null)
        {
            cg.alpha = 0;
            cg.blocksRaycasts = false;
            blackScreen.fadedIn = false;
        }
        else
        {
            cg.alpha = 1;
            cg.blocksRaycasts = true;
            blackScreen.fadedIn = true;
            message.text = errorText.Value;
        }
    }

    public void Ok()
    {
        errorText.Value = null;
    }
}
