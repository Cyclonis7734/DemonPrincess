using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public void newGameButton(string newGameToLoad)
    {
        SceneManager.LoadScene(newGameToLoad);
    }

    public void exitGame()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
