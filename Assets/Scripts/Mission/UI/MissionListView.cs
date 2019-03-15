using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionListView : MonoBehaviour
{
    public GameState saveGame;
    public GameObject missionCardPrefab;

    void OnEnable()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
        Debug.Log("rebuild");

        saveGame.missions.RegisterAction(UpdateCards);
        UpdateCards();
    }

    void OnDisable()
    {
        saveGame.missions.UnregisterAction(UpdateCards);
    }

    public void UpdateCards()
    {
        int cardCountDiff = saveGame.missions.Count - transform.childCount;
        if (cardCountDiff > 0)
        {
            for (int i = 0; i < cardCountDiff; i++)
            {
                Instantiate(missionCardPrefab).transform.SetParent(transform);
            }
        }
        else if (cardCountDiff < 0)
        {
            for (int i = transform.childCount - 1; i >= saveGame.missions.Count; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        MissionCard[] missionCards = GetComponentsInChildren<MissionCard>();
        for (int i = 0; i < saveGame.missions.Count; i++)
        {
            missionCards[i].mission = saveGame.missions[i];
        }
    }
}
