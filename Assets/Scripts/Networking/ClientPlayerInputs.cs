using StarterAssets;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ClientPlayerInput : NetworkBehaviour
{
    private StarterAssetsInputs scr_starterAssetsInputs;
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
        PlayerMoveInputsRpc(scr_starterAssetsInputs.move, scr_starterAssetsInputs.look, scr_starterAssetsInputs.jump, scr_starterAssetsInputs.sprint, mainCamera.transform.eulerAngles);
        PlayerEmotInputsRpc(scr_starterAssetsInputs.EmotOne, scr_starterAssetsInputs.EmotTwo, scr_starterAssetsInputs.EmotThree, scr_starterAssetsInputs.EmotFour);
    }

    [Rpc(SendTo.Server)]
    private void PlayerMoveInputsRpc(Vector2 move, Vector2 look, bool jump, bool sprint, Vector3 rotation)
    {
        scr_starterAssetsInputs.MoveInput(move);
        scr_starterAssetsInputs.LookInput(look);
        scr_starterAssetsInputs.JumpInput(jump);
        scr_starterAssetsInputs.SprintInput(sprint);
        scr_starterAssetsInputs.CameraRotationInput(rotation);
    }

    [Rpc(SendTo.Server)]
    private void PlayerEmotInputsRpc(bool emotOne, bool emotTwo, bool emotThree, bool emotFour)
    {
        scr_starterAssetsInputs.EmotOneInput(emotOne);
        scr_starterAssetsInputs.EmotTwoInput(emotTwo);
        scr_starterAssetsInputs.EmotThreeInput(emotThree);
        scr_starterAssetsInputs.EmotFourInput(emotFour);
    }

}
