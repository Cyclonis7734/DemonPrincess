﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerAttack : MonoBehaviour {

    Animator charAnim;
    public AnimationClip attackAnim;

    void Start()
    {
        charAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Attack") && GetComponent<CharacterControllerDemonForm>().demonForm)
        {
            StartCoroutine(Attack());
        }
        
    }

    IEnumerator Attack()
    {
        charAnim.SetBool("Attack", true);
        yield return new WaitForSeconds(attackAnim.length);
        charAnim.SetBool("Attack", false);
    }
}
