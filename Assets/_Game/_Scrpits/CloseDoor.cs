using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    [SerializeField] private GameObject _door;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") || other.CompareTag("Bot"))
        {
            _door.GetComponent<BoxCollider>().enabled = true;
            _door.GetComponent<Renderer>().enabled = true;
        }
    }
}
