using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowButton : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject window;
    public Transform spawnPoint;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetTrigger("MouseOver");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetTrigger("Idle");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        animator.SetTrigger("Clicked");
        window.SetActive(!window.activeSelf);
        window.transform.position = spawnPoint.transform.position;
        window.transform.SetAsLastSibling();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        animator.SetTrigger("MouseOver");
    }
}
