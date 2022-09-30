using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public GameObject camera;
    public GameObject battlefield;
    public GameObject attackButton;
    public bool isCameraOn;
    private void Start()
    {
        attackButton.SetActive(false);
        isCameraOn = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        camera.GetComponent<CinemachineVirtualCamera>().Follow = battlefield.transform;
        camera.GetComponent<CinemachineVirtualCamera>().LookAt = battlefield.transform;
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("Paths"));
        isCameraOn = true;
        attackButton.SetActive(true);
        //canvas.SetActive(true);
    }
}
