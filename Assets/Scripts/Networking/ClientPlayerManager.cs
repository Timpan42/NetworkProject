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
    [SerializeField] private StarterAssetsInputs starterAssetsInputs;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private CinemachineVirtualCamera cinemaCamera;
    [SerializeField] private ClientPlayerInput clientPlayerInput;
    [SerializeField] private EmotesManger emotesManger;
    [SerializeField] private UiManger uiManger;
    [SerializeField] private Animator animator;
    private float playerTimer = 0;
    private CheckPoint checkPoint = new();


    private void Awake()
    {
        ChangeComponentState(false);
    }

    public override void OnNetworkSpawn()
    {
        uiManger = GameObject.Find("UiManager").GetComponent<UiManger>();
        base.OnNetworkSpawn();

        enabled = IsClient;

        if (IsOwner)
        {
            ChangeComponentState(true);
            GameManger.Instance.OnPlayerWin += OnPlayerWin;
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
        }
    }
    private void OnPlayerWin()
    {
        if (GameManger.Instance.playerWonId.Value == OwnerClientId)
        {
            uiManger.UiWinText();
        }
        else
        {
            uiManger.UiLostText();
        }
        thirdPersonController.enabled = false;
        clientPlayerInput.TernOffMovement();
        animator.enabled = false;
        starterAssetsInputs.enabled = false;
        clientPlayerInput.enabled = false;
        playerInput.enabled = false;

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

    public float GetPlayerTime()
    {
        return playerTimer;
    }

    [Rpc(SendTo.Server)]
    public void UpdateCheckPointRpc(int checkPointId, Vector3 checkPointPosition)
    {
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

}

