using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerMovement : MonoBehaviour {

    Transform sceneCharacter;


    float yPos;
    
    public float rotateSpeed = 100f;

    void Start()
    {
        sceneCharacter = GameObject.FindGameObjectWithTag("Controller").transform;
        yPos = transform.position.y;
    }
    void Update()
    {
        transform.position = new Vector3(sceneCharacter.transform.position.x, yPos, sceneCharacter.transform.position.z);

        if (Input.GetMouseButton(1) == true) //if right click is held, the camera can rotate, otherwise it can't
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * rotateSpeed * Time.deltaTime, Space.Self);
        }


    }
}
