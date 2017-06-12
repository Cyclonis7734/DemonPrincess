using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemySMInterface
{
    void IsIdle();
    void IsWandering();
    void IsPursuing();
    void IsAttacking();
    void IsDead();
}
