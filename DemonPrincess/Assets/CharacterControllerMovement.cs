using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour {

    public Rigidbody character;
    public Animator anim;

    float moveSpeed = 20f;
    float jumpForce = 5f;
    float stopFast = .9f;

    bool isGrounded = true;
    
    private float floAnimJump;
    private float floAnimJumpLeg;
    private bool booAnimCrouch;


    void FixedUpdate()
    {
        Vector3 floFinalMove;
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        if (moveZ > 0) { moveZ += 1; } else if(moveZ < 0) { moveZ -= 1; }
        Vector3 camRight = Camera.main.transform.right * moveX;
        float camForward = Camera.main.transform.forward.z * moveZ;
        Vector3 moveTarget = new Vector3(camRight.x, 0f, camForward);

        //Debug.Log(moveZ + " moveZ");
        //Debug.Log(moveX + " moveX");
        //Debug.Log(camForward + " camForward");
        //Debug.Log(Camera.main.transform.forward + " camfor true");
        //Debug.Log(camRight + " camRight");
        //Vector3 moveTarget = (Input.GetAxis("Vertical") * Camera.main.transform.forward + Input.GetAxis("Horizontal") * Camera.main.transform.right); 
        //for some reason the vertical movement(up, down, "w" and "s", isn't giving a number large enough to move the character unless the character has horizontal movement.
        moveTarget.y = 0f;
        if (isGrounded) //can only move if on the ground, character keeps velocity in air but can't change or add velocity
        {
            floFinalMove = moveTarget * moveSpeed * Time.deltaTime;
            //Debug.Log((moveTarget * moveSpeed * Time.deltaTime).ToString() + " Stuff");
            anim.SetFloat("Forward", floFinalMove.z);
            anim.SetFloat("Turn", floFinalMove.x);
            character.AddForce(floFinalMove, ForceMode.Impulse); //adding force based on target position
        }
        if (moveX == 0 && moveZ == 0)
        {
            character.velocity *= stopFast;
        }
    }

    void Update()
    {
        RaycastHit hit;
        Ray groundCheck = new Ray(transform.position, (Vector3.down * 0.1f));
        if (Physics.Raycast(groundCheck, out hit, 1.2f) == true)
        {
            //Debug.Log("grounded");
            isGrounded = true;
        }
        else
        {
            //Debug.Log("not grounded");
            isGrounded = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jump");
            character.AddRelativeForce(0, jumpForce, 0, ForceMode.VelocityChange);
        }

    }
}
