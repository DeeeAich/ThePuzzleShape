using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartButtonClick()
    {
        SceneManager.LoadScene("Donnacha's working scene");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("How To Play");
    }

    public void QuitButtonClick()
    {
        Application.Quit();
    }
}
