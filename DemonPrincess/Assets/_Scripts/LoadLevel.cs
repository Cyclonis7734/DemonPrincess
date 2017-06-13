using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadLevel : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Controller")
        {
            SceneManager.LoadScene("2nd Level Castle Scene");
        }
    }
}
