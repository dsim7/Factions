
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class AssetSlotCard : MonoBehaviour,
    /*IPointerEnterHandler, IPointerExitHandler,*/ IPointerDownHandler, IPointerUpHandler
{
    Animator animator;
    Transform parentWindow;

    public Sprite defaultImage;

    [SerializeField]
    AssetSlot _assetSlot;
    public AssetSlot assetSlot
    {
        get { return _assetSlot; }

        set
        {
            _assetSlot = value;
            UpdateCard();

            if (_assetSlot != null)
            {
                _assetSlot.RegisterAction(UpdateCard);
            }
        }
    }

    public AssetVariable assetSelect;
    public Image image;
    public AssetVariable assetDrag;

    void Start()
    {
        animator = GetComponent<Animator>();
        parentWindow = GetComponentInParent<DraggableWindow>().transform;
    }

    void OnEnable()
    {
        assetSlot.RegisterAction(UpdateCard);
        UpdateCard();
    }

    void OnDisable()
    {
        assetSlot.UnregisterAction(UpdateCard);
    }

    void UpdateCard()
    {
        if (assetSlot.Value != null && assetSlot.Value.template != null)
        {
            image.sprite = assetSlot.Value.template.image;
        }
        else
        {
            image.sprite = defaultImage;
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
        parentWindow.SetAsLastSibling();

        if (assetSlot.Value != null && assetSlot.Value.template != null)
        {
            assetSelect.Value = assetSlot.Value;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        animator.SetTrigger("MouseOver");
    }

    public void DragStart()
    {
        if (assetSlot.Value != null && !assetSlot.locked)
        {
            assetDrag.Value = assetSlot.Value;
        }
    }

    public void DragEnd()
    {
        assetSlot.Value = assetDrag.Value;
        assetDrag.Value = null;
    }

    public void Drop()
    {
        if (!assetSlot.locked && assetDrag.Value != null && assetDrag.Value.template != null)
        {
            Asset temp = assetSlot.Value;
            assetSlot.Value = assetDrag.Value;
            assetDrag.Value = temp;
        } 
    }
}
