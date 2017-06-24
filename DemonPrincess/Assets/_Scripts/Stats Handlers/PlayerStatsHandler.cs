using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsHandler : StatsHandler {

    protected override void Start()
    {
        floMaxHealth = 50f;
        floCurrentHealth = floMaxHealth;
    }

    protected override void KillEntity()
    {
        Debug.Log("Player has Died...");
    }

}
