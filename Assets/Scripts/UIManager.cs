using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject optionsObject;
    private void Start()
    {
        optionsObject.SetActive(false);
    }
    // Loading main scene from main menu
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
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

    public void PauseMenu()
    {
        SceneManager.LoadScene("Pause");
    }
}
