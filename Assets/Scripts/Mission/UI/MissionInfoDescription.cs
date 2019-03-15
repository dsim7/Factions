using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionInfoDescription : MonoBehaviour
{
    public MissionInstanceVariable selectedMission;
    public Text text;

    void Start()
    {
        selectedMission.RegisterAction(UpdateInfo);
    }

    void UpdateInfo()
    {
        if (selectedMission.Value != null)
        {
            text.text = selectedMission.Value.description;
        }
    }
}
