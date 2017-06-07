using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerMovement : MonoBehaviour {

    public Transform sceneCharacter;

    bool canRotateCamera = false;

    float yPos;
    
    public float rotateSpeed = 100f;

    void Start()
    {
        yPos = transform.position.y;
    }
    void Update()
    {
        transform.position = new Vector3(sceneCharacter.transform.position.x, yPos, sceneCharacter.transform.position.z);

        if (Input.GetMouseButton(1) == true) //if right click is held, the camera can rotate, otherwise it can't
        {
            canRotateCamera = true;
        }
        else
            canRotateCamera = false;

        if(Input.GetAxis("Mouse X") > 0 && canRotateCamera)
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self);
        }
        if(Input.GetAxis("Mouse X") < 0 && canRotateCamera)
        {
            transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime, Space.Self);
        }
    }
}
