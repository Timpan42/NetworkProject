using StarterAssets;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ClientPlayerInput : NetworkBehaviour
{
    private ThirdPersonController scr_thirdPersonController;
    private StarterAssetsInputs scr_starterAssetsInputs;
    private void Start()
    {
        scr_thirdPersonController = GetComponent<ThirdPersonController>();
        scr_starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        PlayerJumpRpc();
        PlayerGroundCheckRpc();
        PlayerMoveRpc();

    }

    [Rpc(SendTo.Server)]
    private void PlayerJumpRpc()
    {
        scr_thirdPersonController.JumpAndGravity();
    }

    [Rpc(SendTo.Server)]
    private void PlayerGroundCheckRpc()
    {
        scr_thirdPersonController.GroundedCheck();

    }

    [Rpc(SendTo.Server)]
    private void PlayerMoveRpc()
    {
        scr_thirdPersonController.Move();
    }

}
