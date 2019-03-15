
using UnityEngine;

public class AgentListView : MonoBehaviour
{
    public GameState saveGame;
    public GameObject agentCardPrefab;
    
    void Start()
    {
        saveGame.agents.RegisterAction(UpdateCards);
        UpdateCards();
    }

    public void UpdateCards()
    {
        int cardCountDiff = saveGame.agents.Count - transform.childCount;
        if (cardCountDiff > 0)
        {
            for (int i = 0; i < cardCountDiff; i++)
            {
                Instantiate(agentCardPrefab).transform.SetParent(transform);
            }
        }
        else if (cardCountDiff < 0)
        {
            for (int i = cardCountDiff; i < 0; i++)
            {
                Destroy(transform.GetChild(transform.childCount - 1).gameObject);
            }
        }

        AgentCard[] agentCards = GetComponentsInChildren<AgentCard>();
        for (int i = 0; i < saveGame.agents.Count; i++)
        {
            agentCards[i].agent = saveGame.agents[i];
        }
    }
}
