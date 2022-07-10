using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    // ========================================= Definitions ========================================
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    // ==============================================================================================
    private void Start()
    {
    }

    private void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector3 movementDirectionVector = new Vector3(horizontalMovement, 0, verticalMovement);
        movementDirectionVector.Normalize();
        transform.Translate(movementDirectionVector * movementSpeed * Time.deltaTime, Space.World);

        if (movementDirectionVector != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirectionVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        
    }

    
}
         
