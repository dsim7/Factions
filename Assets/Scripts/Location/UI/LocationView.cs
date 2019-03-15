using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationView : MonoBehaviour
{
    public GameState saveGame;
    public LocationObjectVariable selectedLocation;
    public ConversationManager conversationManager;
    public Conversation foundNothingConvo;
    public Transform returnLocation;

    public Text locationName;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        selectedLocation.RegisterAction(UpdateLocation);
    }

    void OnDisable()
    {
        selectedLocation.UnregisterAction(UpdateLocation);
    }

    void UpdateLocation()
    {
        if (selectedLocation.Value != null)
        {
            locationName.text = selectedLocation.Value.locationName;
        }
    }

    public void Appear()
    {
        animator.SetTrigger("Open");
        transform.parent.SetAsLastSibling();
    }

    public void Disappear()
    {
        animator.SetTrigger("Close");
    }

    public void Investigate()
    {
        Location location = selectedLocation.Value;
        Mission randomMission = location.potentialMissions[Random.Range(0, location.potentialMissions.Length)];
        if (!saveGame.missions.Contains(randomMission))
        {
            conversationManager.StartConversation(randomMission.introConversation, randomMission.DiscoverMission);
        }
        else
        {
            conversationManager.StartConversation(foundNothingConvo);
        }
        Disappear();
        Return();
    }

    public void Return()
    {
        selectedLocation.Value = null;
        Camera.main.GetComponent<MainCamera>().target = returnLocation;
        Disappear();
    }
}
