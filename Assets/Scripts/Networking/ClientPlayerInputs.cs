using StarterAssets;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ClientPlayerInput : NetworkBehaviour
{
    public StarterAssetsInputs scr_starterAssetsInputs;
    [SerializeField] private Camera mainCamera;

    private void Start()
    {
        scr_starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    private void LateUpdate()
    {
        if (!IsOwner)
        {
            return;
        }
        PlayerInputsRpc(scr_starterAssetsInputs.move, scr_starterAssetsInputs.look, scr_starterAssetsInputs.jump, scr_starterAssetsInputs.sprint, mainCamera.transform.eulerAngles);
    }

    [Rpc(SendTo.Server)]
    private void PlayerInputsRpc(Vector2 move, Vector2 look, bool jump, bool sprint, Vector3 rotation)
    {
        scr_starterAssetsInputs.MoveInput(move);
        scr_starterAssetsInputs.LookInput(look);
        scr_starterAssetsInputs.JumpInput(jump);
        scr_starterAssetsInputs.SprintInput(sprint);
        scr_starterAssetsInputs.CameraRotationInput(rotation);

    }

}
