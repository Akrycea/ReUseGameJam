using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        MusicManager.Instance.PlayMusic("MainTrack");
    }
    public void StartGame()
    {
 
        SceneManager.LoadScene(1);

    }

    public void NexLevel()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ToMainMenu()
    {
       
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        
        Application.Quit();
    }
}
