using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void Load()
    {
       SceneManager.LoadScene("GameplayScene");
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }

    public void SecondLevel()
    {
        SceneManager.LoadScene("SecondLevel");
    }
}
