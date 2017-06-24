using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponDamager : Damager {

    private void Start()
    {
        floAttack = 10f;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        GameObject gamoCollidedWith;
        gamoCollidedWith = collision.gameObject;
        Debug.Log("Collided With: " + gamoCollidedWith.name);
        if (gamoCollidedWith.tag.Equals("Enemy"))
        {
               gamoCollidedWith.GetComponent<EnemyStatsHandler>().ChangeHealth(-floAttack);
        }
    }
}
