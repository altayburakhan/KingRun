using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour
{
    public Transform Enemy;
 
    public List<Transform> AllieList;
 
    private Transform nearestAlly;

    private float speed = 3.5f;
    void Update()
    {
        float minimumDistance = Mathf.Infinity;
        if(nearestAlly!=null)
        {
            nearestAlly.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        nearestAlly = null;
        foreach(Transform allie in AllieList)
        {
            float distance = Vector3.Distance(Enemy.position, allie.position);
            if ( distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestAlly = allie;
            }
        }
        nearestAlly.GetComponent<MeshRenderer>().material.color = Color.green;
        Debug.Log("Nearest Enemy: " + nearestAlly + "; Distance: " + minimumDistance);

        transform.position = Vector3.MoveTowards(transform.position, nearestAlly.transform.position, speed * Time.deltaTime);
    }
}
