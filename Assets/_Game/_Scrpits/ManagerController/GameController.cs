using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController _instance;
    [SerializeField] private SceneManagerment _sceneManagerment;
    public bool isGameWon = false;
    int num = 1;

    private void Awake()
    {
        if (GameController._instance != null) Debug.LogError("Just Have to one Gamecontroller");
        GameController._instance = this;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Reset");
    }

    public void NextLevel(string nameScene)
    {
        nameScene = nameScene + num.ToString();
        _sceneManagerment.GoToScene(nameScene);
        num++;
    }
}
