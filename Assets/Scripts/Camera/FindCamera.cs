using System;
using Cinemachine;
using UnityEngine;

public class FindCamera : MonoBehaviour
{
    private CinemachineVirtualCamera followCamera;
    void Start()
    {
        followCamera = FindAnyObjectByType<CinemachineVirtualCamera>();
        followCamera.Follow = transform;
    }
}
