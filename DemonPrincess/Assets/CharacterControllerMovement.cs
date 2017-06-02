using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour {

    public Rigidbody character;

    float moveSpeed = 10f;
    float jumpForce = 5f;

    bool isGrounded = true;

    

    void FixedUpdate()
    {
        Vector3 moveTarget = (Input.GetAxis("Vertical") * Camera.main.transform.forward + Input.GetAxis("Horizontal") * Camera.main.transform.right); 
        //for some reason the vertical movement(up, down, "w" and "s", isn't giving a number large enough to move the character unless the character has horizontal movement.
        moveTarget.y = 0f;
        if (isGrounded) //can only move if on the ground, character keeps velocity in air but can't change or add velocity
        {
            character.AddRelativeForce(moveTarget * moveSpeed * Time.deltaTime, ForceMode.Impulse); //adding force based on target position
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
            character.AddRelativeForce(0, jumpForce, 0, ForceMode.VelocityChange);
        }

    }
}
