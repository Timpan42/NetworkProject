using Unity.Netcode;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class EmoteVisualizer : NetworkBehaviour
{
    [SerializeField] private EmoteImageScriptable[] emoteImages;
    [SerializeField] private EmoteSignalScriptable[] emoteSignals;
    [SerializeField] private EmoteAnimationScriptable[] emoteAnimationName;
    [SerializeField] private Image playerImage;
    private GameObject currentSignalObject;
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

    public void SignalEmote(int emoteId)
    {

    }
    private void DeactivateSignalEmote()
    {

    }
    public void AnimationEmote(int emoteId)
    {

    }
    private void DeactivateAnimationEmote()
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
                DeactivateSignalEmote();
                break;
            case EmotesManger.EmoteType.Animation:
                DeactivateAnimationEmote();
                break;
        }
    }

}
