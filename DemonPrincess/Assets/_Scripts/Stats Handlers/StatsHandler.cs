using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsHandler : MonoBehaviour {

    protected float floCurrentHealth { get; set; }
    protected float floMaxHealth { get; set; }

    public void ChangeHealth(float floChange)
    {
        Debug.Log(gameObject.name + " Change: " + floChange);
        if(floCurrentHealth + floChange <= 0) { floCurrentHealth = 0f; KillEntity(); }
        else if(floCurrentHealth + floChange >= floMaxHealth) { floCurrentHealth = floMaxHealth; }
        else{ floCurrentHealth = floCurrentHealth + floChange; }
        Debug.Log(gameObject.name + " Health: " + floCurrentHealth);
    }

    protected virtual void Start()
    {
        floMaxHealth = 35f;
        floCurrentHealth = floMaxHealth;
    }

    protected virtual void KillEntity()
    {

    }

}
