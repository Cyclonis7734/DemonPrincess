using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {

    protected float floAttack { get; set; }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        GameObject gamoCollidedWith;
        gamoCollidedWith = collision.gameObject;
        if (gamoCollidedWith.tag.Equals("Controller") || gamoCollidedWith.tag.Equals("Enemy"))
        {
            gamoCollidedWith.GetComponent<StatsHandler>().ChangeHealth(floAttack);
        }
    }
}
