using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MeleeUnit : Unit
{
    protected override void Awake()
    {
        base.Awake();
        for (int i = 0; i < this.levelColors.Length; i++) 
        {
            this.levelColors[i].a = .65f;
        }
        this.unitRange = 2;
        
    }
    protected override void Attack(Unit target)
    {
        if (target.gameObject.activeSelf)
        {
            switch (this.currentStatus)
            {
                case Status.Idle:
                    break;
                case Status.Moving:
                {
                    MoveToTarget(target);
                    break;
                }
                case Status.Attacking:
                {
                    this.currentStatus = Status.Attacking;
                    StartCoroutine(target.TakeDamage(this.unitAttack));
                    break;
                }
            }
        }
        else if (_manager.remainingEnemies.Count != 0)
        {
            Unit nearest = _manager.NearestEnemy(this);
            MoveToTarget(nearest);
        }
        else
        {
            this.currentStatus = Status.Idle;
        }
    }
    
}
