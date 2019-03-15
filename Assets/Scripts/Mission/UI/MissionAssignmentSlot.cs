using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionAssignmentSlot : MonoBehaviour
{
    Image imageComponent;

    public int slotNumber;

    MissionAssignment _missionAssignment;
    public MissionAssignment missionAssignment { get { return _missionAssignment; } set { _missionAssignment = value; UpdateSlot(); } }
    
    public MissionInstanceVariable selectedMission;
    public AgentObjectVariable draggedAgent;
    
    public Image agentImage;
    public Text agentName;
    public MissionAssignmentSlotCancel cancelButton;

    [Space]
    public Sprite defaultSprite;

    void Start()
    {
        imageComponent = GetComponent<Image>();

        selectedMission.RegisterAction(UpdateAssignment);
    }
    
    void UpdateAssignment()
    {
        if (missionAssignment != null && missionAssignment.assignedAgent != null)
        {
            missionAssignment.assignedAgent.UnregisterAction(UpdateSlot);
        }
        missionAssignment = selectedMission.Value.assignments[slotNumber];
        if (missionAssignment != null && missionAssignment.assignedAgent != null)
        {
            missionAssignment.assignedAgent.RegisterAction(UpdateSlot);
        }
    }

    void UpdateSlot()
    {
        if (missionAssignment != null &&
            missionAssignment.assignedAgent != null &&
            missionAssignment.assignedAgent.Value != null)
        {
            agentImage.sprite = missionAssignment.assignedAgent.Value.image;
            agentName.text = missionAssignment.assignedAgent.Value.agentName;
            imageComponent.color = new Color(1f, 1f, 1f);
            missionAssignment.locked.Value = false;
        }
        else
        {
            agentImage.sprite = defaultSprite;
            agentName.text = "(Drag Agent Here)";
            imageComponent.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            missionAssignment.locked.Value = true;
        }
    }

    public void Drop()
    {
        if (CanAssign())
        {
            if (missionAssignment.assignedAgent != null && missionAssignment.assignedAgent.Value != null)
            {
                missionAssignment.assignedAgent.Value.status.Value = AgentStatusEnum.Idle;
            }
            missionAssignment.assignedAgent.Value = draggedAgent.Value;
            draggedAgent.Value.status.Value = AgentStatusEnum.Assigned;
        }
    }

    bool CanAssign()
    {
        return draggedAgent.Value != null &&
            selectedMission.Value.status.Value == MissionStatusEnum.Pending &&
            draggedAgent.Value.status.Value == AgentStatusEnum.Idle &&
            !CheckAgentAlreadyOnMission(draggedAgent.Value) &&
            (!missionAssignment.locked.Value || missionAssignment.assignedAgent.Value == null);
    }

    bool CheckAgentAlreadyOnMission(Agent agent)
    {
        for (int i = 0; i < Mission.MAX_AGENTS; i++)
        {
            if (selectedMission.Value.assignments[i].assignedAgent.Value != null &&
                selectedMission.Value.assignments[i].assignedAgent.Value == agent)
            {
                return true;
            }
        }
        return false;
    }
}
