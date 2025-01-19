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
                OnPlayerWin?.Invoke(player.OwnerClientId);
            }
        }
    }
}
