using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionAssignmentSlotCancel : MonoBehaviour
{
    public int slotNumber;
    public MissionInstanceVariable selectedMission;

    BoolVariable _assignmentLocked;
    public BoolVariable assignmentLocked { get { return _assignmentLocked; } set { _assignmentLocked = value; UpdateButton(); } }

    Button buttonComponent;

    void Start()
    {
        buttonComponent = GetComponent<Button>();
    }

    void OnEnable()
    {
        selectedMission.RegisterAction(UpdateLocked);
    }

    void OnDisable()
    {
        selectedMission.UnregisterAction(UpdateLocked);
    }

    void UpdateLocked()
    {
        if (assignmentLocked != null)
        {
            assignmentLocked.UnregisterAction(UpdateButton);
        }
        assignmentLocked = selectedMission.Value.assignments[slotNumber].locked;
        if (assignmentLocked != null)
        {
            assignmentLocked.RegisterAction(UpdateButton);
        }
    }
    
    void UpdateButton()
    {
        buttonComponent.interactable = !assignmentLocked.Value;
    }
    
    public void ClearAssignmentAgent()
    {
        selectedMission.Value.assignments[slotNumber].assignedAgent.Value.status.Value = AgentStatusEnum.Idle;
        selectedMission.Value.assignments[slotNumber].assignedAgent.Value = null;
    }

}
