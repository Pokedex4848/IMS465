using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour
{
    public GameObject homeScreen, creditsScreen;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenCredits()
    {
        creditsScreen.SetActive(true);
        homeScreen.SetActive(false);
    }

    public void CloseCredits()
    {
        homeScreen.SetActive(true);
        creditsScreen.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
