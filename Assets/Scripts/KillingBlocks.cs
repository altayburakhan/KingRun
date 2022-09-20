using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingBlocks : MonoBehaviour
{
    public Animator gameOver;
    private static readonly int isKilled = Animator.StringToHash("isKilled");
    private static readonly int isRunning = Animator.StringToHash("isRunning");
    private CharacterMove _characterMove;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameOver.SetBool(isKilled, true);
    }

    private void Update()
    {
        
    }
}
