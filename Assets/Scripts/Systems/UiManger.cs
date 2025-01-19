using TMPro;
using UnityEngine;

public class UiManger : MonoBehaviour
{
    [SerializeField] private GameObject uiWinningObject;


    public void UiWinText()
    {
        TextMeshProUGUI uiText = uiWinningObject.GetComponentInChildren<TextMeshProUGUI>();
        uiText.text = "You Have Won";
        uiWinningObject.SetActive(true);
    }

    public void UiLostText()
    {
        TextMeshProUGUI uiText = uiWinningObject.GetComponentInChildren<TextMeshProUGUI>();
        uiText.text = "You Have Lost";
        uiWinningObject.SetActive(true);
    }


}
