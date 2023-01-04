using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 1f;
    }
    public void Play()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("GameScene");
    }

    public void menu()
    {

        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
