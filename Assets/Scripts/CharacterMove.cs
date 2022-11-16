using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class CharacterMove : MonoBehaviour
{
    // ========================================= Definitions ========================================
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    private float movementLimit;
    public Animator runningAnimation;
    private static readonly int isRunning = Animator.StringToHash("isRunning");
    public bool checkDied;
    public Joystick _joystick;
    
    private void Start()
    {
        checkDied = false;
    }

    private void Update()
    {
        
        movementLimit = transform.position.x;
        float horizontalMovement = _joystick.Horizontal;
        float verticalMovement = _joystick.Vertical;
        verticalMovement = Mathf.Clamp01(verticalMovement); // If the y axis is forward/back then minus is backwards, this will clamp the value between 0-1 so you can only go forward, not backward.
        
        // ================================================== Movement =====================================================
        if (!checkDied)
        {
        
            Debug.Log("asd");
            Vector3 movementDirectionVector = new Vector3(horizontalMovement, 0, verticalMovement);
            movementDirectionVector.Normalize();
            transform.Translate(movementDirectionVector * (movementSpeed * Time.deltaTime), Space.World);
            
        
            // ================================================== Rotation =====================================================
    
            if (movementDirectionVector != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirectionVector, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        if ((horizontalMovement != 0 || verticalMovement != 0) && !checkDied)
        {
            runningAnimation.SetBool(isRunning , true);
        }else
            runningAnimation.SetBool(isRunning , false);
           
        
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
         
