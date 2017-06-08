using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public float speed;
    private int direction = 1;
   
    
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * speed * direction * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target" )
        {
            if (direction == 1)
            {
               
                direction = -1;
                Debug.Log("direction is now -1");
            }
            else
            {
                direction = 1;
                Debug.Log("Direction changed to 1");
            }
        }
        if (other.tag == "Controller")
        {
            other.transform.parent = transform;
        }
    }
    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Controller")
        {
            other.transform.parent = null;
        }
    }
}
