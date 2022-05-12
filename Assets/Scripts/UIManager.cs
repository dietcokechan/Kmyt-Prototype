using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject optionsObject;
    
    void Start()
    {
        optionsObject.SetActive(false);
    }

    // Loading main scene from main menu
    public void StartGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

    // Exiting game
    public void ExitGame()
    {
        Application.Quit();
    }

    // Go to main menu from pause menu
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Go to pause menu scene
    public void PauseMenu()
    {
        SceneManager.LoadScene("Pause");
    }
}
