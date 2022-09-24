using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public GameObject camera;
    public GameObject battlefield;

    private void OnCollisionEnter(Collision collision)
    {
        camera.GetComponent<CinemachineVirtualCamera>().Follow = battlefield.transform;
        camera.GetComponent<CinemachineVirtualCamera>().LookAt = battlefield.transform;
        Destroy(GameObject.Find("Player"));
    }
}
