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
            if (collider.GetComponent<PlayerManger>())
            {
                SendCheckPointData(collider.GetComponent<PlayerManger>());
            }
        }
    }
    private void SendCheckPointData(PlayerManger playerManger)
    {
        playerManger.UpdateCheckPointRpc(checkPointId, checkPointPosition);
    }
}

