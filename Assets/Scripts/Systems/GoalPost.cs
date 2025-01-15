using UnityEngine;

public class GoalPost : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (collider.GetComponent<PlayerManger>())
            {
                collider.GetComponent<PlayerManger>().UpdatePlayerInGoalRpc(true);
                Debug.Log("You win");
            }
        }
    }
}
