using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyS_Pursuing : EnemySMInterface
{
    Enemy ESM;

    //Constructor
    public EnemyS_Pursuing(Enemy newESM)
    {
        ESM = newESM;
    }

    public void IsAttacking()
    {
        ESM.SetEnemyState(ESM.getIsAttacking());
        ESM.HandleAttacking();
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
        ESM.PursuePlayer();
    }

}
