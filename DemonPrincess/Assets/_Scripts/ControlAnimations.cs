using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimations : MonoBehaviour {

    private Animator anim;
    private float floTurning;
    private float floMoving;
    private Rigidbody rgbdy;
    private float floAdjust = 20f;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rgbdy = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {

        floMoving = Input.GetAxis("Vertical");
        floTurning = Input.GetAxis("Horizontal");
        anim.SetFloat("floMove", floMoving);
        anim.SetFloat("floTurn", floTurning);
        float floMoveX = floMoving * floAdjust * Time.deltaTime;
        float floMoveZ = floTurning * floAdjust * Time.deltaTime;

        
        
    }
}
