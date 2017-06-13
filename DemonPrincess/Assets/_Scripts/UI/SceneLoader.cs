using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {


    void Start()
    {
        //DontDestroyOnLoad(gameObject);
    }

	public void LoadTutorialScene()
    {
        SceneManager.LoadScene("Castle Scene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("2nd Level Castle Scene");
    }

    public void LoadTestScene()
    {
        SceneManager.LoadScene("Beginning");
    }
}
