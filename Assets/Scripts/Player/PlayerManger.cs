using System.Threading.Tasks;
using UnityEngine;

public class PlayerManger : MonoBehaviour
{
    private float playerTimer = 0;
    private CheckPoint checkPoint = new();
    private bool playerInGoal = false;
    public void UpdatePlayerTimer(float timeAmount)
    {
        playerTimer += timeAmount;
    }

    public float GetPlayerTime()
    {
        return playerTimer;
    }

    public void UpdateCheckPoint(int checkPointId, Transform checkPointTransform)
    {
        checkPoint.currentCheckPointId = checkPointId;
        checkPoint.currentCheckPointTransform = checkPointTransform;
    }
    public async void TeleportToCheckPoint()
    {
        Debug.Log(checkPoint.currentCheckPointTransform.position);
        await Task.Delay(100);
        transform.position = checkPoint.currentCheckPointTransform.position;
    }

    public void UpdatePlayerInGoal(bool state)
    {
        playerInGoal = state;
    }

}
