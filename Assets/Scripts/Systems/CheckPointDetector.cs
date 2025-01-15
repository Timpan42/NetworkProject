using Unity.Netcode;
using UnityEngine;

public class CheckPointDetector : NetworkBehaviour
{
    [SerializeField] private int checkPointId = 0;
    [SerializeField] private Transform checkPointTransform;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (collider.GetComponent<PlayerManger>())
            {
                SendCheckPointData(collider.GetComponent<PlayerManger>());
            }
        }
    }
    private void SendCheckPointData(PlayerManger playerManger)
    {
        playerManger.UpdateCheckPointRpc(checkPointId, checkPointTransform);
    }

}
