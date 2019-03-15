using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreen : MonoBehaviour
{
    CanvasGroup cg;

    bool _fadedIn;
    public bool fadedIn { get { return _fadedIn; } set { _fadedIn = value; cg.blocksRaycasts = _fadedIn; } }
    bool _fadedInFull;
    public bool fadedInFull { get { return _fadedInFull; } set { _fadedInFull = value; cg.blocksRaycasts = _fadedInFull; } }

    void Start ()
    {
        cg = GetComponent<CanvasGroup>();

        cg.alpha = 1;
        fadedInFull = true;
	}
	
	void Update ()
    {
        cg.alpha = Mathf.Lerp(cg.alpha, _fadedIn ? 0.6f : _fadedInFull ? 1f : 0, Time.deltaTime * 5f);
	}
}
