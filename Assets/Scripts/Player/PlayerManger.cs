using System.Threading.Tasks;
using StarterAssets;
using Unity.Netcode;
using UnityEngine;

public class PlayerManger : NetworkBehaviour
{
    private float playerTimer = 0;
    private CheckPoint checkPoint = new();
    private bool playerInGoal = false;
    [SerializeField] private ThirdPersonController scr_thirdPersonController;

    //[Rpc(SendTo.Server)]
    public void UpdatePlayerTimerRpc(float timeAmount)
    {
        playerTimer += timeAmount;
    }

    public float GetPlayerTime()
    {
        return playerTimer;
    }

    public void UpdateCheckPointRpc(int checkPointId, Vector3 checkPointPosition)
    {
        Debug.Log(name + "new checkpoint");
        checkPoint.currentCheckPointId = checkPointId;
        checkPoint.currentCheckPointPosition = checkPointPosition;
    }

    public void TeleportToCheckPointRpc()
    {
        scr_thirdPersonController.enabled = false;
        transform.position = checkPoint.currentCheckPointPosition;
        TurnOnMovement();
    }
    private async void TurnOnMovement()
    {
        await Task.Delay(100);
        scr_thirdPersonController.enabled = true;
    }

    //[Rpc(SendTo.Server)]
    public void UpdatePlayerInGoalRpc(bool state)
    {
        playerInGoal = state;
    }

}
