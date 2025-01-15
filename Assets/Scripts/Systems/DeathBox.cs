using UnityEngine;

public class DeathBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (collider.GetComponent<PlayerManger>())
            {
                Debug.Log(collider.name + ": collided");
                collider.GetComponent<PlayerManger>().TeleportToCheckPointRpc();
            }
        }
    }
}
