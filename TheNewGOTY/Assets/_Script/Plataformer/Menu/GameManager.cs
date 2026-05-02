using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void EndGame()
    {
        SceneManager.LoadScene(2);
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
