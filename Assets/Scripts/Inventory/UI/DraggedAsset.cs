using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggedAsset : MonoBehaviour
{
    public AssetVariable draggedAsset;
    public Image image;

    bool isActive = false;

    void Start()
    {
        draggedAsset.RegisterAction(UpdateImage);
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
        if (draggedAsset.Value != null && draggedAsset.Value.template != null)
        {
            image.color = new Color(1, 1, 1, 0.5f);
            image.sprite = draggedAsset.Value.template.image;
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
