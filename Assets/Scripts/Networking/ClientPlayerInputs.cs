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
        PlayerEmoteInputsRpc(scr_starterAssetsInputs.EmoteOne, scr_starterAssetsInputs.EmoteTwo, scr_starterAssetsInputs.EmoteThree, scr_starterAssetsInputs.EmoteFour);
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
    private void PlayerEmoteInputsRpc(bool emoteOne, bool emoteTwo, bool emoteThree, bool emoteFour)
    {
        scr_starterAssetsInputs.EmoteOneInput(emoteOne);
        scr_starterAssetsInputs.EmoteTwoInput(emoteTwo);
        scr_starterAssetsInputs.EmoteThreeInput(emoteThree);
        scr_starterAssetsInputs.EmoteFourInput(emoteFour);
    }

}
