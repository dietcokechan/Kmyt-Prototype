using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject dialogue;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void DeleteDialogue()
    {
        Destroy(dialogue);
    }
}
