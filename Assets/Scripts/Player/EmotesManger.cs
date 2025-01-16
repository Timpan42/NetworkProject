using System.Threading.Tasks;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private int deactivateEmotTimer = 1000;
    [SerializeField] private EmotVisualizer emotVisualizer;

    private void ActivateEmote()
    {



    }

    private async void DeactivateEmote()
    {
        await Task.Delay(deactivateEmotTimer);

    }

}
