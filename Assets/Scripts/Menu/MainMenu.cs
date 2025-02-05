using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Credits()
    {
        SceneManager.LoadScene(3);
    }

    public void Controls()
    {
        SceneManager.LoadScene(4);
    }

    public void Quit()
    {
        Application.Quit();
    }
   
}
