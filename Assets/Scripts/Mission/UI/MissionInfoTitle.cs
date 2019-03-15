using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionInfoTitle : MonoBehaviour
{
    public MissionInstanceVariable selectedMission;
    public Text text;

    void Start()
    {
        selectedMission.RegisterAction(UpdateInfo);
    }

    void UpdateInfo()
    {
        text.text = selectedMission.Value.title;
    }
}
