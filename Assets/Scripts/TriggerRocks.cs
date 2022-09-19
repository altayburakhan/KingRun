using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRocks : MonoBehaviour
{
    //private Transform[] allchildrenofrocks;
    public List<GameObject> Children;
    public GameObject rocks;

    private void Start()
    {
        foreach (Transform child in rocks.transform)
        {
            if (child.CompareTag("Projectile"))
            {
                Children.Add(child.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < Children.Count; i++)
        {
            Children[i].GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
