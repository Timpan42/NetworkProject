using System;
using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance { get; private set; }
    private bool isTimerOn = false;
    private float currentTime;
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
            string str = time.ToString(@"hh\:mm\:ss\:fff");
            Debug.Log(str);
            yield return new WaitForEndOfFrame();
        }
    }

}

