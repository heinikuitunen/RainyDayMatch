using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

}
