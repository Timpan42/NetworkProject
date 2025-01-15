using System;
using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using TMPro;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance { get; private set; }
    private bool isTimerOn = false;
    private float currentTime;
    [SerializeField] private TextMeshProUGUI timerText;

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
    private void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        isTimerOn = true;
        while (isTimerOn)
        {
            currentTime += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            timerText.text = time.ToString(@"hh\:mm\:ss\:f");
            yield return new WaitForEndOfFrame();
        }
    }

}

