using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathLoad1 : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Controller"))
        {
            SceneManager.LoadScene("Castle Scene");
        }
        
    }

}
