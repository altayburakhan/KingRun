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
    private float movementLimit;
    public Animator runningAnimation;
    private static readonly int isRunning = Animator.StringToHash("isRunning");

    private void Update()
    {
        movementLimit = transform.position.x;
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        verticalMovement = Mathf.Clamp01(verticalMovement); // If the y axis is forward/back then minus is backwards, this will clamp the value between 0-1 so you can only go forward, not backward.

        // ================================================== Movement =====================================================

        Vector3 movementDirectionVector = new Vector3(horizontalMovement, 0, verticalMovement);
        movementDirectionVector.Normalize();
        transform.Translate(movementDirectionVector * (movementSpeed * Time.deltaTime), Space.World);
        if (horizontalMovement != 0 || verticalMovement != 0)
        {
            runningAnimation.SetBool(isRunning , true);
        }else
            runningAnimation.SetBool(isRunning , false);
        
    // ================================================== Rotation =====================================================
    
        if (movementDirectionVector != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirectionVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    // ============================================ Avoid falling corners ==============================================
    
        if (movementLimit >= 2.61000f)
        {
            transform.position = new Vector3(2.60999f, 1.24f, transform.position.z);
        }
        if (movementLimit <= -2.11000f)
        {
            transform.position = new Vector3(-2.10999f, 1.24f, transform.position.z);
        }
    }
}
         
