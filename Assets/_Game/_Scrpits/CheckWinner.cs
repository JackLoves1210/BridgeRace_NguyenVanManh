using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinner : MonoBehaviour
{

    [SerializeField] public Transform _targetWinner;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] CameraMovement cameraMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            LoadWinner();
            other.gameObject.GetComponent<AnimationController>().PlayWin();
            other.transform.position = Vector3.Lerp(other.transform.position, _targetWinner.position, 10 * Time.deltaTime);
            other.transform.localRotation = Quaternion.Euler(0, 180, 0);
            StartCoroutine(LoadWinCanvas());
        }
        if (other.gameObject.CompareTag("Bot"))
        {
            LoadWinner();
            other.gameObject.GetComponent<AnimationController>().PlayWin();
            other.transform.position = Vector3.Lerp(other.transform.position, _targetWinner.position, 10 * Time.deltaTime);
            other.transform.localRotation = Quaternion.Euler(0, 180, 0);
            StartCoroutine(LoadLoseCanvas());
           
        }
    }

    void LoadWinner()
    {
        playerMovement._joystick.gameObject.SetActive(false);
        GameController._instance.isGameWon = true;
        playerMovement.StopMoveToForward();
        cameraMovement.enabled = false;
    }

    IEnumerator LoadWinCanvas()
    {
        yield return new WaitForSeconds(1.0f);
        UIManager.Ins.OpenUI<Win>();
    }


    IEnumerator LoadLoseCanvas()
    {
        yield return new WaitForSeconds(1.0f);
        UIManager.Ins.OpenUI<Lose>();
    }
}
