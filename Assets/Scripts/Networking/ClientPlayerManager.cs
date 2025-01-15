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
        cinemaCamera.enabled = state;
        clientPlayerInput.enabled = state;
    }

}

