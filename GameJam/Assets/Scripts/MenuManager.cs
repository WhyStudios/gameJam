using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    public bool isPaused { get => paused; }

    private bool paused;
    
    public bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    public void SetPauseMenu()
    {
        paused = !paused;

        Time.timeScale = (paused) ? 0f : 1f;
        pauseMenu.SetActive(paused);
    }

    public void SetGameOverMenu()
    {
        Time.timeScale = 0f;
        gameOverMenu.SetActive(true);
    }

    public void LoadScene(int scene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }

}
