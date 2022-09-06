using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingBlocks : MonoBehaviour
{
private bool gameOver;
    private void OnCollisionEnter(Collision collision)
    {
        gameOver = true;
    }

    private void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
        }
    }
}
