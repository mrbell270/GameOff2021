using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject OptionsMenu;
    public GameObject CreditsMenu;

    private void Awake()
    {
        OptionsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void QuitGame()
    {
        Debug.Log("QUITTING GAME...");
        Application.Quit();
    }
}
