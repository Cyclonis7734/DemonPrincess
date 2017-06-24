using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBallScript : MonoBehaviour {

    Rigidbody demonBall;
    public GameObject instPos;

    float lifeTime;
    float speed;

    void Start()
    {
        demonBall = GetComponent<Rigidbody>();
        lifeTime = 3f;
        speed = 400f;
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
        Debug.Log(instPos.GetComponent<Transform>().forward);
        demonBall.AddForce(instPos.GetComponent<Transform>().forward * speed * Time.deltaTime, ForceMode.VelocityChange);
    }
    
    


}
