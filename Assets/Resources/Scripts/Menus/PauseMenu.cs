using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject OptionsMenu;

    private void Awake()
    {
        OptionsMenu.SetActive(false);
    }

    public void ResumeGame()
    {
        Player player = Player.GetInstance();
        if(player != null) player.SetRunning();
        SceneManager.UnloadSceneAsync(1);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
