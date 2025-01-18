using System.Threading.Tasks;
using Cinemachine;
using StarterAssets;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClientPlayerManager : NetworkBehaviour
{

    [SerializeField] private CharacterController characterController;
    [SerializeField] private ThirdPersonController thirdPersonController;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private CinemachineVirtualCamera cinemaCamera;
    [SerializeField] private ClientPlayerInput clientPlayerInput;
    [SerializeField] private EmotesManger emotesManger;
    private float playerTimer = 0;
    private CheckPoint checkPoint = new();
    private bool playerInGoal = false;


    private void Awake()
    {
        ChangeComponentState(false);
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        enabled = IsClient;

        if (IsOwner)
        {
            ChangeComponentState(true);
        }
        else if (IsServer)
        {
            ChangeComponentState(false);
            characterController.enabled = true;
            thirdPersonController.enabled = true;
            clientPlayerInput.enabled = true;

        }
        else
        {
            enabled = false;
            ChangeComponentState(false);
            return;
        }
    }

    private void ChangeComponentState(bool state)
    {
        characterController.enabled = state;
        thirdPersonController.enabled = state;
        playerInput.enabled = state;
        mainCamera.enabled = state;
        mainCamera.GetComponent<AudioListener>().enabled = state;
        cinemaCamera.enabled = state;
        clientPlayerInput.enabled = state;
        emotesManger.enabled = state;
    }

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
    public void UpdateCheckPointRpc(int checkPointId, Vector3 checkPointPosition)
    {
        Debug.Log(name + "new checkpoint");
        checkPoint.currentCheckPointId = checkPointId;
        checkPoint.currentCheckPointPosition = checkPointPosition;
    }

    [Rpc(SendTo.Server)]
    public void TeleportToCheckPointRpc()
    {
        thirdPersonController.enabled = false;
        transform.position = checkPoint.currentCheckPointPosition;
        TurnOnMovement();
    }
    private async void TurnOnMovement()
    {
        await Task.Delay(100);
        thirdPersonController.enabled = true;
    }

    [Rpc(SendTo.Server)]
    public void UpdatePlayerInGoalRpc(bool state)
    {
        playerInGoal = state;
    }

}

