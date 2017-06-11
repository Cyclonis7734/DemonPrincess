using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerMovement : MonoBehaviour {

    Transform sceneCharacter;


    float yPos;
    public float xOffset;
    public float zOffset;
    
    public float rotateSpeed = 100f;

    void Start()
    {
        sceneCharacter = GameObject.FindGameObjectWithTag("Controller").transform;
        yPos = transform.position.y;
        transform.position = new Vector3(sceneCharacter.transform.position.x, yPos, sceneCharacter.transform.position.z);
    }
    void Update()
    {
        //Vector3 charV3 = new Vector3(sceneCharacter.transform.position.x, sceneCharacter.transform.position.y, sceneCharacter.transform.position.z);
        float charX = sceneCharacter.transform.position.x;
        float charZ = sceneCharacter.transform.position.z;
        float camX = transform.position.x;
        float camZ = transform.position.z;

        if(charX <= Screen.width * .8f || charX >= Screen.width * .2f)
        {
            transform.position = new Vector3(sceneCharacter.transform.position.x, yPos, sceneCharacter.transform.position.z);
        }

        //if (charX >= camX + xOffset || charZ >= camZ + zOffset || charX <= camX - xOffset || charZ <= camZ - zOffset)
        //{
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(sceneCharacter.transform.position.x, yPos, sceneCharacter.transform.position.z), 60f);
        //}



        //transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * rotateSpeed * Time.deltaTime, Space.Self);
        if (Input.mousePosition.x > Screen.width * .95)
                transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime, Space.Self);
            if (Input.mousePosition.x < Screen.width * .05)
                transform.Rotate(new Vector3(0, -1, 0) * rotateSpeed * Time.deltaTime, Space.Self);

        


    }
}
