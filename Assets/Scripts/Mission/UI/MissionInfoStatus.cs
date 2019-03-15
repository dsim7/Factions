using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionInfoStatus : MonoBehaviour
{
    MissionStatus _missionStatus;
    public MissionStatus missionStatus { get { return _missionStatus; } set { _missionStatus = value; UpdateInfo(); } }
    public MissionInstanceVariable selectedMission;
    public StringVariable errorText;
    public ConversationManager conversationManager;
    public Text text;
    public MissionInfoPanel infoPanel;

    public string NoAgentsOnMissionText = "There are no agents assigned.";

    public GameObject start;
    public GameObject inProgress;
    public GameObject complete;

    void Start()
    {
        selectedMission.RegisterAction(UpdateStatus);
    }

    public void UpdateStatus()
    {
        if (missionStatus != null)
        {
            missionStatus.UnregisterAction(UpdateInfo);
        }
        missionStatus = selectedMission.Value.status;
        if (missionStatus != null)
        {
            missionStatus.RegisterAction(UpdateInfo);
        }
    }

    public void UpdateInfo()
    {
        text.text = selectedMission.Value.status.Value.ToString();

        if (selectedMission.Value.status.Value == MissionStatusEnum.Pending)
        {
            start.SetActive(true);
            inProgress.SetActive(false);
            complete.SetActive(false);
        }
        else if (selectedMission.Value.status.Value == MissionStatusEnum.Active)
        {
            start.SetActive(false);
            inProgress.SetActive(true);
            complete.SetActive(false);
        }
        else if (selectedMission.Value.status.Value == MissionStatusEnum.Complete)
        {
            start.SetActive(false);
            inProgress.SetActive(false);
            complete.SetActive(true);
        }
        else if (selectedMission.Value.status.Value == MissionStatusEnum.Ended)
        {
            infoPanel.SetDisplayed(false);
        }
    }

    public void StartMission()
    {
        if (Array.Exists(selectedMission.Value.assignments, a => a.assignedAgent.Value != null))
        {
            selectedMission.Value.StartMission();
        }
        else
        {
            errorText.Value = NoAgentsOnMissionText;
        }
    }

    void Update()
    {
        if (selectedMission.Value != null &&
            selectedMission.Value.completeTime != 0 &&
            selectedMission.Value.status.Value != MissionStatusEnum.Complete &&
            DateTime.Now.Ticks > selectedMission.Value.completeTime)
        {
            selectedMission.Value.CompleteMission();
        }
    }

    public void EndMission()
    {
        selectedMission.Value.EndMission();

        if (selectedMission.Value.isSuccess)
        {
            Debug.Log("mission success");
            conversationManager.StartConversation(selectedMission.Value.successConversation, selectedMission.Value.ClaimReward);
        }
        else
        {
            Debug.Log("mission fail");
            conversationManager.StartConversation(selectedMission.Value.failConversation);
        }
    }
}
