using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsHandler : StatsHandler {

    protected override void Start()
    {
        floMaxHealth = 20f;
        floCurrentHealth = floMaxHealth;
    }

    protected override void KillEntity()
    {
        GetComponent<Enemy>().StartDeathSet();
    }
}
