using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScreen : MonoBehaviour
{
    Animator animator;
    CanvasGroup cg;

    public CanvasGroup baseUI;
    public BlackScreen blackScreen;

    void Start()
    {
        animator = GetComponent<Animator>();
        cg = GetComponent<CanvasGroup>();
        StartCoroutine(IntroSequence());
        
    }

    IEnumerator IntroSequence()
    {
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("FadeIn");

        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            yield return null;
        }

        yield return new WaitForSeconds(2f);
        blackScreen.fadedInFull = false;
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("FadeOut");

        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Faded"))
        {
            yield return null;
        }

        cg.blocksRaycasts = false;
        baseUI.blocksRaycasts = true;
        baseUI.GetComponent<Animator>().SetTrigger("FadeIn");
    }
}
