using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ChoiceInteraction : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("mage"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("barbarian"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("warrior"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("archer"))
        {
            Destroy(other.gameObject);
        }
    }

    /*private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("mage"))
        {
            Destroy(hit.gameObject);
        }
        if (hit.gameObject.CompareTag("barbarian"))
        {
            Destroy(hit.gameObject);
        }
        if (hit.gameObject.CompareTag("warrior"))
        {
            Destroy(hit.gameObject);
        }
        if (hit.gameObject.CompareTag("archer"))
        {
            Destroy(hit.gameObject);
        }
    }*/
}
