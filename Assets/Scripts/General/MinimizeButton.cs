using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimizeButton : MonoBehaviour
{
    public Sprite[] images = new Sprite[2];
    public GameObject window;
    public Image image;

    public void ToggleDisplay()
    {
        window.SetActive(!window.activeSelf);
        image.sprite = images[window.activeSelf ? 0 : 1];
        transform.parent.SetAsLastSibling();
    }
}
