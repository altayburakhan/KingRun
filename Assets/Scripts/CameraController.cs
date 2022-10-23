using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject joystick;
    public GameObject camera;
    public GameObject battlefield;
    public GameObject attackButton;
    public GameObject gameManager;
    public bool isCameraOn;
    public CinemachineVirtualCamera vcam;
    private void Start()
    {
        attackButton.SetActive(false);
        isCameraOn = false;
        gameManager.SetActive(false);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        var transposer = vcam.GetCinemachineComponent<CinemachineTransposer>();
        camera.GetComponent<CinemachineVirtualCamera>().Follow = battlefield.transform;
        camera.GetComponent<CinemachineVirtualCamera>().LookAt = battlefield.transform;
        transposer.m_FollowOffset = new Vector3(0,5.7f,-3.95f);
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("Paths"));
        isCameraOn = true;
        attackButton.SetActive(true);
        joystick.SetActive(false);
        gameManager.SetActive(true);
        //canvas.SetActive(true);
    }
}
