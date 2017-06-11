using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBallScript : MonoBehaviour {

    Rigidbody demonBall;
    public GameObject character;

    float lifeTime;
    float speed;

    void Start()
    {
        demonBall = GetComponent<Rigidbody>();
        lifeTime = 3f;
        speed = 200f;
        Movement();
        StartCoroutine(DemonBallTimer());
    }

    public IEnumerator DemonBallTimer()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    public void Movement()
    {
        Vector3 forward = character.transform.InverseTransformDirection(Vector3.forward);
        demonBall.AddRelativeForce(forward * speed * Time.deltaTime, ForceMode.VelocityChange);
    }
    
    


}
