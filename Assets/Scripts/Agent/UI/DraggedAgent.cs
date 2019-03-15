
using UnityEngine;
using UnityEngine.UI;

public class DraggedAgent : MonoBehaviour
{
    public AgentObjectVariable draggedAgent;
    public Image image;

    bool isActive = false;

    void Start()
    {
        draggedAgent.RegisterAction(UpdateImage);
    }

    void Update()
    {
        if (isActive)
        {
            transform.position = Input.mousePosition;
        }
    }

    void UpdateImage()
    {
        if (draggedAgent.Value != null)
        {
            image.color = new Color(1, 1, 1, 0.5f);
            image.sprite = draggedAgent.Value.image;
            transform.SetAsLastSibling();
            isActive = true;
        }
        else
        {
            image.color = new Color(0, 0, 0, 0);
            isActive = false;
        }
    }
}
