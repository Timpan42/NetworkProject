using System;
using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using TMPro;
using Unity.Netcode;
using Unity.VisualScripting;

public class GameManger : NetworkBehaviour
{
    public static GameManger Instance { get; private set; }
    private bool isTimerOn = false;
    public NetworkVariable<float> currentTime;
    public bool HasHost = false;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform joinButtonHoler;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
        }
    }
    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        HasHost = true;
        WhenJoin();
        StartCoroutine(Timer());
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
        WhenJoin();
    }

    private void WhenJoin()
    {
        mainCamera.enabled = false;
        mainCamera.GetComponent<AudioListener>().enabled = false;
        joinButtonHoler.gameObject.SetActive(false);
    }

    private IEnumerator Timer()
    {
        isTimerOn = true;
        while (isTimerOn)
        {
            currentTime.Value += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

}

