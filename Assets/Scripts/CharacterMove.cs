using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody rigidbodyOfPlayer;
    private float speedOfPlayer;
    private Vector3 playerForwardVector;
   
    private void Start()
    {
        
        rigidbodyOfPlayer = GetComponent<Rigidbody>();
        speedOfPlayer = 20f;
    }

    private void Update()
    {
        playerForwardVector = new Vector3(Input.GetAxis("Horizontal"),0,1);
        Debug.Log(playerForwardVector);
        rigidbodyOfPlayer.MovePosition(transform.position + playerForwardVector * Time.deltaTime * speedOfPlayer);
    }
    
}