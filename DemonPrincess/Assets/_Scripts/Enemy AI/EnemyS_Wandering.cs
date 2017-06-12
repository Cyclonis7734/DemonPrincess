using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyS_Wandering : EnemySMInterface
{
    Enemy ESM;

    //Constructor
    public EnemyS_Wandering(Enemy newESM)
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

    }

    public void IsWandering()
    {
        ESM.HandleWandering();
    }

    public void IsPursuing()
    {
        ESM.SetEnemyState(ESM.getIsPursuing());
        ESM.PursuePlayer();
    }
}
