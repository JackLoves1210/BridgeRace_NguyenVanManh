using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinner : MonoBehaviour
{

    [SerializeField] private Transform _targetWinner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bot"))
        {
            Debug.Log("win win");
            other.gameObject.GetComponent<AnimationController>().PlayWin();
            other.transform.position = Vector3.Lerp(other.transform.position, _targetWinner.position, 10 * Time.deltaTime);
        }
    }
}
