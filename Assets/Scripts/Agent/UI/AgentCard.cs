
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class AgentCard : MonoBehaviour,
    /*IPointerEnterHandler, IPointerExitHandler,*/ IPointerDownHandler, IPointerUpHandler
{
    Animator animator;
    Transform parentWindow;

    [SerializeField]
    Agent _agent;
    public Agent agent
    {
        get { return _agent; }

        set
        {
            if (_agent != value)
            {
                _agent = value;
                UpdateCard();
            }
        }
    }

    public AgentObjectVariable agentSelect;
    public Text agentName;
    public Image image;
    public AgentObjectVariable agentDrag;

    void Start()
    {
        animator = GetComponent<Animator>();
        parentWindow = GetComponentInParent<DraggableWindow>().transform;

        UpdateCard();
    }

    void UpdateCard()
    {
        if (_agent != null)
        {
            agentName.text = agent.agentName;
            image.sprite = agent.image;
        }
    }

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    animator.SetTrigger("MouseOver");
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    animator.SetTrigger("Idle");
    //}

    public void OnPointerDown(PointerEventData eventData)
    {
        animator.SetTrigger("Clicked");
        agentSelect.Value = _agent;
        parentWindow.SetAsLastSibling();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        animator.SetTrigger("MouseOver");
    }
    
    public void DragStart()
    {
        agentDrag.Value = agent;
    }
    
    public void DragEnd()
    {
        agentDrag.Value = null;
    }
}
