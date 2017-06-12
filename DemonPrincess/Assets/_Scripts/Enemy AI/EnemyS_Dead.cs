using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyS_Dead : EnemySMInterface
{
    Enemy ESM;

    //Constructor
    public EnemyS_Dead(Enemy newESM)
    {
        ESM = newESM;
    }

    public void IsAttacking() { }
    public void IsDead() { }
    public void IsIdle() { }
    public void IsWandering() { }
    public void IsPursuing() { }
}
