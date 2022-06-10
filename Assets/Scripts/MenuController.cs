using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Pong 2D");
        Debug.Log("Created by Ahmad Shahal Mahfudz - 149251970101-134");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
