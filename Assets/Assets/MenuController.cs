using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().ToString() == "MenuScene")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
}
