
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class MissionCard : MonoBehaviour,
    /*IPointerEnterHandler, IPointerExitHandler,*/ IPointerDownHandler, IPointerUpHandler
{
    Animator animator;
    Transform parentWindow;
    
    [SerializeField]
    Mission _mission;
    public Mission mission
    {
        get { return _mission; }

        set
        {
            if (_mission != value)
            {
                // Listen to mission's status and remove this card when the mission is done
                if (_mission != null)
                {
                    _mission.status.UnregisterAction(RemoveOnComplete);
                }
                _mission = value;
                UpdateCard();
                if (_mission != null)
                {
                    _mission.status.RegisterAction(RemoveOnComplete);
                }
            }
        }
    }

    public MissionInstanceVariable missionSelect;
    public MissionList currentMissions;
    public Text title;
    public Text description;

    void Start()
    {
        animator = GetComponent<Animator>();
        parentWindow = GetComponentInParent<DraggableWindow>().transform;

        UpdateCard();
    }

    void UpdateCard()
    {
        if (_mission != null)
        {
            title.text = mission.title;
            description.text = mission.description;
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
        missionSelect.Value = mission;
        parentWindow.SetAsLastSibling();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        animator.SetTrigger("MouseOver");
    }

    public void RemoveOnComplete()
    {
        if (_mission.status.Value == MissionStatusEnum.Ended)
        {
            currentMissions.Remove(_mission);
        }
    }
}
