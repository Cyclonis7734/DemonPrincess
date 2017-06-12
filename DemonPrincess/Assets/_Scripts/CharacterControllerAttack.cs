﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerAttack : MonoBehaviour {

    Animator charAnim;
    public AnimationClip attackAnim;
    public GameObject demonBall;
    public GameObject instantiatePosition;

    public bool isAttacking = false;

    void Start()
    {
        charAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Attack") && GetComponent<CharacterControllerDemonForm>().demonForm && !isAttacking)
        {
            StartCoroutine(Attack());
        }
        
    }

    IEnumerator Attack()
    {
        charAnim.SetBool("Attack", true);
        isAttacking = true;
        yield return new WaitForSeconds(attackAnim.length / 2);
        Kamehameha();
        yield return new WaitForSeconds(attackAnim.length / 2);
        charAnim.SetBool("Attack", false);
        isAttacking = false;
    }

    public void Kamehameha()
    {
        Instantiate(demonBall, instantiatePosition.transform.position, Quaternion.identity);
    }
}
