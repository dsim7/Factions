using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionInfoStats : MonoBehaviour
{
    public Text duration, stealthReq, intReq, charReq, combatReq;
    
    public MissionInstanceVariable selectedMission;

    void Start()
    {
        selectedMission.RegisterAction(UpdateInfo);
    }

    void UpdateInfo()
    {
        duration.text = selectedMission.Value.durationInSeconds.ToString();
        stealthReq.text = selectedMission.Value.stealthReq.ToString();
        intReq.text = selectedMission.Value.intellectReq.ToString();
        charReq.text = selectedMission.Value.charismaReq.ToString();
        combatReq.text = selectedMission.Value.combatReq.ToString();
    }
}
