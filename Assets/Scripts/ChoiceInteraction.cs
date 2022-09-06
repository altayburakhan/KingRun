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

        if (other.gameObject.CompareTag("mage"))
        {
            Destroy(other.gameObject);
            boxCollider =  parentOfColliderObject.GetComponentsInChildren<BoxCollider>();
            foreach (BoxCollider colliders in boxCollider)
            {
                colliders.enabled = false;
            }
            countMage++;
        }
        if (other.gameObject.CompareTag("barbarian"))
        {
            Destroy(other.gameObject);
            boxCollider =  parentOfColliderObject.GetComponentsInChildren<BoxCollider>();
            foreach (BoxCollider colliders in boxCollider)
            {
                colliders.enabled = false;
            }
            countBarbarian++;
        }
        if (other.gameObject.CompareTag("warrior"))
        {
            Destroy(other.gameObject);
            boxCollider =  parentOfColliderObject.GetComponentsInChildren<BoxCollider>();
            foreach (BoxCollider colliders in boxCollider)
            {
                colliders.enabled = false;
            }
            countWarrior++;
        }
        if (other.gameObject.CompareTag("archer"))
        {
            Destroy(other.gameObject);
            boxCollider =  parentOfColliderObject.GetComponentsInChildren<BoxCollider>();
            foreach (BoxCollider colliders in boxCollider)
            {
                colliders.enabled = false;
            }
            countArcher++;
        }
    }
    
}
