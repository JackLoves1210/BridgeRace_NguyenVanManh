using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] private GameObject _bricks;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bot"))
        {
            SetActiveBrick();
            obj.GetComponent<Renderer>().enabled = false;
            obj.GetComponent<BoxCollider>().enabled = false;
        }
    }
    
    void SetActiveBrick()
    {
        foreach  (Transform item in _bricks.transform)
        {
            item.gameObject.SetActive(false);
        }
    }
    
}
