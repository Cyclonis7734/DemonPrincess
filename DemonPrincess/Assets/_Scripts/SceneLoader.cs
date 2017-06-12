using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadTutorialScene()
    {
        SceneManager.LoadScene("Castle Scene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
