using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody rigidbodyOfPlayer; 
    private float speedOfPlayer = 20f;
    // Player`s Vector.
    private Vector3 playerForwardVector;
    // Touch Vectors.
    private Vector3 startTouchPosition;
    private Vector3 currentPosition;
    private Vector3 endTouchPosition;
    private bool stopTouch = false;
    public float swipeRange;
    public float tapRange;
   
    private void Start()
    {
        // Setting player`s Rigidbody and its speed.
        rigidbodyOfPlayer = GetComponent<Rigidbody>();
        speedOfPlayer = 20f;
    }

    private void Update()
    {
        Swipe();
        playerForwardVector = new Vector3(0,0,1);
        Debug.Log(playerForwardVector);
        rigidbodyOfPlayer.MovePosition(transform.position + playerForwardVector * Time.deltaTime * speedOfPlayer);
    }

    // Touch Method.
    public void Swipe()
    {
        // If player touch screen FIRST-ONE time  
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
                    //Statement
                    stopTouch = true;
                }

                else if (Distance.x > swipeRange)
                {
                    //Statement
                    stopTouch = true;
                }
                
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            endTouchPosition = Input.GetTouch(0).position;
            Vector3 Distance = endTouchPosition - startTouchPosition;
            /*if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                
            }*/
        }
        
    }
}