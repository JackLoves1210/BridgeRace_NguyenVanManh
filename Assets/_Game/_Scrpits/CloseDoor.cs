using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _bricks;
    [SerializeField] private GameObject _bricksInFloor;
    //  [SerializeField] private GameObject _player;
    [SerializeField] private GetColor _getColorCharacter;

    private void Start()
    {
        SetColor();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bot"))
        {
            SetActiveFloor_1();
            _door.GetComponent<BoxCollider>().enabled = true;
            _door.GetComponent<Renderer>().enabled = true;
            SetActiveBrickInFloor();
        }
    }

    void SetActiveFloor_1()
    {
        foreach (Transform item in _bricks.transform)
        {
            
            if (item.GetComponent<ResourceGenerator>()._number == _getColorCharacter._numColor)
            {
                item.gameObject.SetActive(true);
            }
        }
    }


    private void SetActiveBrickInFloor()
    {
        foreach (Transform item in _bricksInFloor.transform)
        {
            if (item.GetComponent<ResourceGenerator>()._number == _getColorCharacter._numColor)
            {
                item.gameObject.SetActive(false);
            }
        }
    }

    private void SetColor()
    {
        foreach (Transform item in _bricks.transform)
        {
            item.gameObject.SetActive(true);
        }
    }
}
