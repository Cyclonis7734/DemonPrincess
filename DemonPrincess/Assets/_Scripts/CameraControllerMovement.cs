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

        
            //transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * rotateSpeed * Time.deltaTime, Space.Self);
            if (Input.mousePosition.x > Screen.width * .95)
                transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime, Space.Self);
            if (Input.mousePosition.x < Screen.width * .05)
                transform.Rotate(new Vector3(0, -1, 0) * rotateSpeed * Time.deltaTime, Space.Self);

        


    }
}
