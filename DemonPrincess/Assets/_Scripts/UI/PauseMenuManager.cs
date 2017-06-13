using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenuManager : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject loadMenu;

    float timeScale;

    void Start()
    {
        timeScale = 1;
    }

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPauseGame();
        }
    }

    public void OnPauseGame()
    {
        if (pauseMenu.activeSelf)
        {
            OffPauseGame();
        }
        else if (!pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        
    }

    public void OffPauseGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = timeScale;
    }

    public void OnLoadGame()
    {
        pauseMenu.SetActive(false);
        loadMenu.SetActive(true);
        Time.timeScale = timeScale;
    }

    public void OffLoadGame()
    {
        pauseMenu.SetActive(true);
        loadMenu.SetActive(false);
    }

}
