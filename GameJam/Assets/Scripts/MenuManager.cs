using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public Text distanceText;

    public bool isPaused { get => paused; }

    private bool paused;
    
    //public bool IsMouseOverUI()
    //{
    //    return EventSystem.current.IsPointerOverGameObject();
    //}

    public void SetDistance(int distance)
    {
        distanceText.text = distance.ToString();
    }

    public void SetPauseMenu()
    {
        paused = !paused;

        Time.timeScale = (paused) ? 0f : 1f;
        pauseMenu.SetActive(paused);
    }

    public void SetGameOverMenu()
    {
        //Time.timeScale = 0f;
        gameOverMenu.SetActive(true);
    }

    public void LoadScene(int scene)
    {
        Time.timeScale = 1f;

        if (scene == 1) GameManager.SetDefaultValues();

        SceneManager.LoadScene(scene);
    }

}
