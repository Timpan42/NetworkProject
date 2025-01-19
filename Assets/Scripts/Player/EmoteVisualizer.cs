using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class EmoteVisualizer : NetworkBehaviour
{
    [SerializeField] private EmoteImageScriptable[] emoteImages;
    [SerializeField] private EmoteSignalScriptable[] emoteSignals;
    [SerializeField] private EmoteAnimationScriptable[] emoteAnimationName;
    [SerializeField] private Image playerImage;
    private GameObject currentSignalObject;
    [SerializeField] private Transform spawnSignalPoint;
    [SerializeField] private Animator animator;
    private string animationName;


    [Rpc(SendTo.Everyone)]
    public void ImageEmoteRpc(int emoteId)
    {
        Debug.Log("image");
        Sprite sprite = null;

        foreach (EmoteImageScriptable emote in emoteImages)
        {
            if (emote.EmoteId == emoteId)
            {
                sprite = emote.EmoteImage;
                break;
            }
        }

        if (sprite == null)
        {
            Debug.LogError("sprite for Image Emote dose not exist");
            return;
        }
        playerImage.sprite = sprite;
        playerImage.enabled = true;

    }

    [Rpc(SendTo.Everyone)]
    private void DeactivateImageEmoteRpc()
    {
        playerImage.enabled = false;
        playerImage.sprite = null;
    }

    [Rpc(SendTo.ClientsAndHost)]
    public void SignalEmoteRpc(int emoteId)
    {
        foreach (EmoteSignalScriptable emote in emoteSignals)
        {
            if (emote.EmoteId == emoteId)
            {
                currentSignalObject = emote.EmoteSignal;
                break;
            }
        }
        if (currentSignalObject == null)
        {
            Debug.LogError("GameObject for Signal Emote dose not exist");
            return;
        }
        currentSignalObject = Instantiate(currentSignalObject, spawnSignalPoint);
    }

    [Rpc(SendTo.ClientsAndHost)]
    private void DeactivateSignalEmoteRpc()
    {
        Destroy(currentSignalObject);
    }

    public void AnimationEmoteRpc(int emoteId)
    {

    }
    private void DeactivateAnimationEmoteRpc()
    {

    }


    public void DeactivateEmote(EmotesManger.EmoteType emoteType)
    {
        switch (emoteType)
        {
            case EmotesManger.EmoteType.Image:
                DeactivateImageEmoteRpc();
                break;
            case EmotesManger.EmoteType.Signal:
                DeactivateSignalEmoteRpc();
                break;
            case EmotesManger.EmoteType.Animation:
                DeactivateAnimationEmoteRpc();
                break;
        }
    }

}
