using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentInfoInventory : MonoBehaviour
{
    public GameObject assetSlotPrefab;
    public AgentObjectVariable selectedAgent;

    void OnEnable()
    {
        selectedAgent.RegisterAction(UpdateCards);
    }

    void OnDisable()
    {
        selectedAgent.UnregisterAction(UpdateCards);
    }

    public void UpdateCards()
    {
        int cardCountDiff = selectedAgent.Value.inventory.Count - transform.childCount;
        if (cardCountDiff > 0)
        {
            for (int i = 0; i < cardCountDiff; i++)
            {
                Debug.Log("create");
                Instantiate(assetSlotPrefab).transform.SetParent(transform);
            }
        }
        else if (cardCountDiff < 0)
        {
            for (int i = transform.childCount - 1; i >= selectedAgent.Value.inventory.Count; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        AssetSlotCard[] assetSlots = GetComponentsInChildren<AssetSlotCard>();
        for (int i = 0; i < selectedAgent.Value.inventory.Count; i++)
        {
            assetSlots[i].assetSlot = selectedAgent.Value.inventory[i];
        }
    }
}
