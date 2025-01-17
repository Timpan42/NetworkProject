using System.Threading.Tasks;
using StarterAssets;
using Unity.Netcode;
using UnityEngine;

public class EmotesManger : MonoBehaviour
{
    public enum EmoteType
    {
        Image,
        Signal,
        Animation
    }

    [SerializeField] private int deactivateEmoteTimer = 1000;
    [SerializeField] private StarterAssetsInputs inputs;
    [SerializeField] private EmoteVisualizer emoteVisualizer;
    [SerializeField] private EmoteSignalScriptable emoteSignalScriptableOne;
    [SerializeField] private EmoteSignalScriptable emoteSignalScriptableTwo;
    [SerializeField] private EmoteImageScriptable emoteImageScriptable;
    [SerializeField] private EmoteAnimationScriptable emoteAnimationScriptable;
    private bool EmoteActive = false;
    private void Update()
    {
        CheckEmoteInput();
    }

    private void CheckEmoteInput()
    {
        if (!EmoteActive)
        {
            if (inputs.EmoteOne)
            {
                ActivateEmoteRpc(EmoteType.Signal, emoteSignalScriptableOne.EmoteId);
            }
            else if (inputs.EmoteTwo)
            {
                ActivateEmoteRpc(EmoteType.Signal, emoteSignalScriptableTwo.EmoteId);
            }

            if (inputs.EmoteThree)
            {
                ActivateEmoteRpc(EmoteType.Image, emoteImageScriptable.EmoteId);
                Debug.Log("input");
            }

            if (inputs.EmoteFour)
            {
                ActivateEmoteRpc(EmoteType.Animation, emoteAnimationScriptable.EmoteId);
            }

        }
    }
    [Rpc(SendTo.Server)]
    private void ActivateEmoteRpc(EmoteType emoteType, int emoteId)
    {
        switch (emoteType)
        {
            case EmoteType.Image:
                emoteVisualizer.ImageEmoteRpc(emoteId);
                goto default;

            case EmoteType.Signal:
                emoteVisualizer.SignalEmote(emoteId);
                goto default;

            case EmoteType.Animation:
                emoteVisualizer.AnimationEmote(emoteId);
                goto default;

            default:
                EmoteActive = true;
                DeactivateEmote(emoteType);
                break;
        }
    }

    private async void DeactivateEmote(EmoteType emoteType)
    {
        await Task.Delay(deactivateEmoteTimer);
        emoteVisualizer.DeactivateEmote(emoteType);
        EmoteActive = false;
    }

}
