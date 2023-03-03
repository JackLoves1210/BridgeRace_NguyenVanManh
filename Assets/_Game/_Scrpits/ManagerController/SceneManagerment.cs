using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerment : MonoBehaviour
{
    static int num = 1;
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Reset");
    }

    public void NextLevel(string nameScene)
    {
        num++;
        nameScene = nameScene + num.ToString();
        GoToScene(nameScene);
    }
}
