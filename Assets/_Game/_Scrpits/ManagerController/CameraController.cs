using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _winnerBoard;
    void Update()
    {
        if (GameController._instance.isGameWon)
        {
            transform.LookAt(_winnerBoard);
        }
    }
}
