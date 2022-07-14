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
    public float obje;
    
    private void Update()
    {
        obje = transform.position.x;
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        verticalMovement = Mathf.Clamp01(verticalMovement); // If the y axis is forward/back then minus is backwards, this will clamp the value between 0-1 so you can only go forward, not backward.
        
    // ================================================== Movement =====================================================
    
        Vector3 movementDirectionVector = new Vector3(horizontalMovement, 0, verticalMovement);
        movementDirectionVector.Normalize();
        transform.Translate(movementDirectionVector * movementSpeed * Time.deltaTime, Space.World);
        
    // ================================================== Rotation =====================================================
    
        if (movementDirectionVector != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirectionVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    // ============================================ Avoid falling corners ==============================================
    
        if (obje >= 4.510f)
        {
            transform.position = new Vector3(4.509f, 0, transform.position.z);
        }
        if (obje <= -4.510f)
        {
            transform.position = new Vector3(-4.509f, 0, transform.position.z);
        }
    }
}
         
