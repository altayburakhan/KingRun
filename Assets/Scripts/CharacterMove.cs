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
    private bool right, left;
    private Vector3 playersPosition;
    // Touch Vectors.
    private Vector3 startTouchPosition;
    private Vector3 currentPosition;
    private Vector3 endTouchPosition;
    private bool stopTouch = false;
    
    public float swipeRange;
       
    private void Start()
    {
        // Setting player`s Rigidbody and its speed.
        rigidbodyOfPlayer = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Vector3 horizontalMove = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Vector3 goRight = new Vector3(2.5f, transform.position.y, transform.position.z);
        Vector3 goLeft = new Vector3(-2.5f, transform.position.y, transform.position.z);
        //Swipe();
        playerForwardVector = new Vector3(0,0,1);
        //Debug.Log(playerForwardVector);
        rigidbodyOfPlayer.MovePosition(transform.position + playerForwardVector * Time.deltaTime * speedOfPlayer);
        //transform.Translate(0,0,speedOfPlayer * Time.deltaTime);
        
    }

    // Touch Method.
    public void Swipe()
    {
        Vector2 left = new Vector2(-2.5f, transform.position.y);
        Vector2 right = new Vector2(2.5f, transform.position.y);
        //playersPosition = transform.position;
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
                    Debug.Log("left");
                    //transform.position = Vector3.Lerp(playersPosition,left, 5 );
                    transform.position = Vector3.Lerp(transform.position, left, 3f * Time.deltaTime);
                    stopTouch = true;
                }

                else if (Distance.x > swipeRange)
                {
                    //Statement
                    //transform.position = Vector3.Lerp(playersPosition,right, 5 );
                    transform.position = Vector3.Lerp(transform.position, right, 3f * Time.deltaTime);
                    Debug.Log("Right");
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
        
    }
}