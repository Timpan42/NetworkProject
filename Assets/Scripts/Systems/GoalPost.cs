using System;
using UnityEngine;

public class GoalPost : MonoBehaviour
{
    public event Action<ulong> OnPlayerWin;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (collider.GetComponent<ClientPlayerManager>())
            {
                ClientPlayerManager player = collider.GetComponent<ClientPlayerManager>();
                player.UpdatePlayerInGoalRpc(true);
                OnPlayerWin?.Invoke(player.OwnerClientId);
                Debug.Log("You win");
            }
        }
    }
}
