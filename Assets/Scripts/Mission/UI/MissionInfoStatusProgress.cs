using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionInfoStatusProgress : MonoBehaviour
{
    public MissionInstanceVariable selectedMission;
    public Image progressBar;

	void Update()
    {
        UpdateProgressBar();
    }

    void UpdateProgressBar()
    {
        Mission mission = selectedMission.Value;
        float ratio = (float) (DateTime.Now.Ticks - mission.startTime) /
            (mission.completeTime - mission.startTime);

        progressBar.fillAmount = ratio;
    }

}
