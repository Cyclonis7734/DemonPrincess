using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathLoad : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Controller"))
        {
            SceneManager.LoadScene("2nd Level Castle Scene");
        }
        
    }

}
