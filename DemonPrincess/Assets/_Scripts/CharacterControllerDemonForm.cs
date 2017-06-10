using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerDemonForm : MonoBehaviour {

    Animator anim;

    public bool demonForm;

    void Start()
    {
        anim = GetComponent<Animator>();
        demonForm = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeForm();
        }
    }

    void ChangeForm()
    {
        if (!demonForm)
        {
            anim.SetBool("Demon", true);
            demonForm = true;
            Debug.Log("Demon Form");
        }
        else
        {
            anim.SetBool("Demon", false);
            demonForm = false;
            Debug.Log("Princess Form");
        }
    }
}
