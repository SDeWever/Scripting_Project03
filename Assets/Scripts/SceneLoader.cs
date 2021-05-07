using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseGame();
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
