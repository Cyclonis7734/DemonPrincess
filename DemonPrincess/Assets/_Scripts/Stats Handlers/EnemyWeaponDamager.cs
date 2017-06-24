using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponDamager : Damager {

    private void Start()
    {
        floAttack = 5f;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        GameObject gamoCollidedWith;
        gamoCollidedWith = collision.gameObject;
        Debug.Log("Collided With: " + gamoCollidedWith.name);
        if (gamoCollidedWith.tag.Equals("Controller"))
        {
            gamoCollidedWith.GetComponent<PlayerStatsHandler>().ChangeHealth(-floAttack);
        }
    }
}
