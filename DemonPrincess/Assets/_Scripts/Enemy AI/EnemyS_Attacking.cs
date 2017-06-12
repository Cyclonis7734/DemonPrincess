using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyS_Attacking : EnemySMInterface
{
    Enemy ESM;

    //Constructor
    public EnemyS_Attacking(Enemy newESM)
    {
        ESM = newESM;
    }

    public void IsAttacking()
    {

    }

    public void IsDead()
    {
        ESM.SetEnemyState(ESM.getIsDeathSet());
        ESM.KillThisEnemy();
    }

    public void IsIdle()
    {
        ESM.SetEnemyState(ESM.getIsIdle());
        ESM.StartCoroutine(ESM.IHandleLostPlayer());
    }

    public void IsWandering()
    {

    }

    public void IsPursuing()
    {
        ESM.SetEnemyState(ESM.getIsPursuing());
        ESM.PursuePlayer();
    }
}
