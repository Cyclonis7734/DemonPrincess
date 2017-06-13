using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMenuManager : MonoBehaviour {

    public GameObject loadMenu;
    public GameObject mainMenu;

    public void OnLoadGame()
    {
        loadMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OffLoadGame()
    {
        loadMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
