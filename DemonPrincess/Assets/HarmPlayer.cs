using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmPlayer : MonoBehaviour {
    public int damageDealt = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag== "Controller")
        {
            Debug.Log("Player loses " + damageDealt);
        }
    }
}
