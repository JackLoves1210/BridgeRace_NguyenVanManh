using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] GameObject link;
    [SerializeField] private GameObject _listBricks;
    [SerializeField] private Character _character;
    [SerializeField] private Character _character_1;

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

        link.SetActive(true);
        foreach  (Transform item in _listBricks.transform)
        {
            item.gameObject.SetActive(true);
        }
        
        _character._isCheckList = false;
        _character.GetListBrickTarget(_listBricks.transform);
        _character_1._isCheckList = false;
        _character_1.GetListBrickTarget(_listBricks.transform);

    }
    
}
