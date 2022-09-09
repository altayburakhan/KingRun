using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ChoiceInteraction : MonoBehaviour
{
    public BoxCollider[] boxCollider;
    public int countMage, countWarrior, countArcher, countBarbarian;
    private void OnTriggerEnter(Collider other)
    {
        
        var parentOfColliderObject = other.transform.parent.gameObject;

        if (other.gameObject.CompareTag("Mage"))
        {
            Destroy(other.gameObject);
            boxCollider =  parentOfColliderObject.GetComponentsInChildren<BoxCollider>();
            foreach (BoxCollider colliders in boxCollider)
            {
                colliders.enabled = false;
            }
            countMage++;
            Debug.Log("mage");
        }
        if (other.gameObject.CompareTag("Barbarian"))
        {
            Destroy(other.gameObject);
            boxCollider =  parentOfColliderObject.GetComponentsInChildren<BoxCollider>();
            foreach (BoxCollider colliders in boxCollider)
            {
                colliders.enabled = false;
            }
            countBarbarian++;
            Debug.Log("barbar");
        }
        if (other.gameObject.CompareTag("Warrior"))
        {
            Destroy(other.gameObject);
            boxCollider =  parentOfColliderObject.GetComponentsInChildren<BoxCollider>();
            foreach (BoxCollider colliders in boxCollider)
            {
                colliders.enabled = false;
            }
            countWarrior++;
            Debug.Log("warrior");
        }
        if (other.gameObject.CompareTag("Archer"))
        {
            Destroy(other.gameObject);
            boxCollider =  parentOfColliderObject.GetComponentsInChildren<BoxCollider>();
            foreach (BoxCollider colliders in boxCollider)
            {
                colliders.enabled = false;
            }
            countArcher++;
            Debug.Log("archer");
        }
    }
    
}
