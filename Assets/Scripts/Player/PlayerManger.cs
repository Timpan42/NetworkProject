using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;

public class PlayerManger : NetworkBehaviour
{
    private float playerTimer = 0;
    private CheckPoint checkPoint = new();
    private bool playerInGoal = false;

    //[Rpc(SendTo.Server)]
    public void UpdatePlayerTimerRpc(float timeAmount)
    {
        playerTimer += timeAmount;
    }

    public float GetPlayerTime()
    {
        return playerTimer;
    }

    [Rpc(SendTo.Server)]
    public void UpdateCheckPointRpc(int checkPointId, Transform checkPointTransform)
    {
        checkPoint.currentCheckPointId = checkPointId;
        checkPoint.currentCheckPointTransform = checkPointTransform;
    }

    // [Rpc(SendTo.Server)]
    public void TeleportToCheckPointRpc()
    {
        Debug.Log(checkPoint.currentCheckPointTransform.position);
        transform.position = checkPoint.currentCheckPointTransform.position;
    }

    //[Rpc(SendTo.Server)]
    public void UpdatePlayerInGoalRpc(bool state)
    {
        playerInGoal = state;
    }

}
