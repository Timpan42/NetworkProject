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
    private void Awake()
    {
        ChangeComponentState(false);
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        enabled = IsClient;

        if (!IsOwner)
        {
            enabled = false;
            ChangeComponentState(false);
            return;
        }

        ChangeComponentState(true);
    }

    private void ChangeComponentState(bool state)
    {
        characterController.enabled = state;
        thirdPersonController.enabled = state;
        playerInput.enabled = state;
        mainCamera.enabled = state;
        cinemaCamera.enabled = state;
    }

}

