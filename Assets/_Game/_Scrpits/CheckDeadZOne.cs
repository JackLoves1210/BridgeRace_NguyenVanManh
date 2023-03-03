using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDeadZOne : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            UIManager.Ins.OpenUI<Lose>();
        }
    }
}
