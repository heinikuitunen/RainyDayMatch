using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Room");
    }

    public void Credits()
    {
        SceneManager.LoadScene("HowToPlay");
    }


    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }

}
