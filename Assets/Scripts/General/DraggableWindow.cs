﻿
using UnityEngine;

public class DraggableWindow : MonoBehaviour
{
    float offsetX, offsetY;

    public void DragBegin()
    {
        offsetX = transform.position.x - Input.mousePosition.x;
        offsetY = transform.position.y - Input.mousePosition.y;
    }

    public void OnDrag()
    {
        transform.position = new Vector3(offsetX + Input.mousePosition.x, offsetY + Input.mousePosition.y);
    }
}
