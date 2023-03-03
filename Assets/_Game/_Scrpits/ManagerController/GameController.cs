using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController _instance;
    public bool isGameWon = false;


    private void Awake()
    {
        if (GameController._instance != null) Debug.LogError("Just Have to one Gamecontroller");
        GameController._instance = this;
    }
}
