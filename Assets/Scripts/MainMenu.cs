using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public string SceneName;
   public void StartGame()
    {
        // Load the main menu scene
        SceneManager.LoadScene(SceneName);
    }

    public void OnApplicationQuit()
    {
        // Quit the application when the game is closed
        Application.Quit();
    }
}

