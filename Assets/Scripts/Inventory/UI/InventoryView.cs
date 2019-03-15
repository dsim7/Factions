
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    public GameState saveGame;
    public GameObject assetPrefab;
    
    void Start()
    {
        saveGame.inventory.RegisterAction(UpdateCards);
        UpdateCards();
    }

    public void UpdateCards()
    {
        int cardCountDiff = saveGame.inventory.Count - transform.childCount;
        if (cardCountDiff > 0)
        {
            for (int i = 0; i < cardCountDiff; i++)
            {
                Instantiate(assetPrefab).transform.SetParent(transform);
            }
        }
        else if (cardCountDiff < 0)
        {
            for (int i = transform.childCount - 1; i >= saveGame.inventory.Count; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        AssetSlotCard[] assetSlots = GetComponentsInChildren<AssetSlotCard>();
        for (int i = 0; i < saveGame.inventory.Count; i++)
        {
            assetSlots[i].assetSlot = saveGame.inventory[i];
        }
    }
}
