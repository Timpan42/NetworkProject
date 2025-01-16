using Unity.Netcode;
using UnityEngine;

public class CheckPointDetector : MonoBehaviour
{
    [SerializeField] private int checkPointId = 0;
    [SerializeField] private Transform checkPointTransform;
    private Vector3 checkPointPosition;

    private void Start()
    {
        checkPointPosition = checkPointTransform.position;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (collider.GetComponent<ClientPlayerManager>())
            {
                SendCheckPointData(collider.GetComponent<ClientPlayerManager>());
            }
        }
    }
    private void SendCheckPointData(ClientPlayerManager playerManger)
    {
        playerManger.UpdateCheckPointRpc(checkPointId, checkPointPosition);
    }
}

