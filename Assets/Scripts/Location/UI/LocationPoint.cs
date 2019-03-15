using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LocationPoint : MonoBehaviour, IPointerClickHandler
{
    public LocationObjectVariable selectedLocation;
    public Location location;

    public Transform view;
    public LocationView locationView;

    public void OnPointerClick(PointerEventData eventData)
    {
        selectedLocation.Value = location;
        Camera.main.GetComponent<MainCamera>().target = view;
        locationView.Appear();
    }
    
}
