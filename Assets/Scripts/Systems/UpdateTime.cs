using System;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class UpdateTime : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        GameManger.Instance.currentTime.OnValueChanged += UpdateTimer;
    }

    public override void OnNetworkDespawn()
    {
        base.OnNetworkDespawn();
        GameManger.Instance.currentTime.OnValueChanged -= UpdateTimer;
    }

    private void UpdateTimer(float previousTime, float newTime)
    {
        TimeSpan time = TimeSpan.FromSeconds(newTime);
        timerText.text = time.ToString(@"hh\:mm\:ss\:f");
    }

}
