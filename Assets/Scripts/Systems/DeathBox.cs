using UnityEngine;

public class DeathBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (collider.GetComponent<PlayerManger>())
            {
                collider.GetComponent<PlayerManger>().TeleportToCheckPoint();
            }
        }
    }
}
