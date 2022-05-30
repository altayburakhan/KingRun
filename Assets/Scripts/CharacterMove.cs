using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 characterDirection;
    private Vector3 startTouchPosition;
    private Vector3 currentPosition;
    private Vector3 endTouchPosition;
    private bool stopTouch = false;
    private float swipeRange;
    private float forwardSpeed = 10f;
    private int desiredLane = 0; // 0 = left, 1 = right
    private float laneDistance = 4; // The distance between two lanes.

    private void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    private void Update()
    {
        Vector2 left = new Vector2(-2.5f, transform.position.y);
        Vector2 right = new Vector2(2.5f, transform.position.y);
        characterDirection.z = forwardSpeed;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector3 Distance = currentPosition - startTouchPosition;
            if (!stopTouch)
            {
                if (Distance.x < -swipeRange)
                {
                    Debug.Log("left");
                    desiredLane--;
                    if (desiredLane == -1)
                    {
                        desiredLane = 0;
                    }

                    stopTouch = true;
                }

                else if (Distance.x > swipeRange)
                {
                    Debug.Log("Right");
                    desiredLane++;
                    if (desiredLane == 2)
                    {
                        desiredLane = 1;
                    }

                    stopTouch = true;
                }

            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            endTouchPosition = Input.GetTouch(0).position;
            Vector3 Distance = endTouchPosition - startTouchPosition;

        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 1)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = targetPosition;

    }

    private void FixedUpdate()
    {
        controller.Move(characterDirection * Time.fixedDeltaTime);
    }
}
         
