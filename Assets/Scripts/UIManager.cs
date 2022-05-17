using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject optionsObject;
    public GameObject raceObject;
    public GameObject dialogue;
    
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
        Destroy(dialogue);
    }

    // Load race scene but as an additive scene instead of loading it
    public void LoadRace()
    {
        SceneManager.LoadScene("Race", LoadSceneMode.Additive);
        Destroy(dialogue);
    }

    // Destroy the additive scene by destroying the parent object
    public void DestroyRace()
    {
        Destroy(raceObject);
    }
}
