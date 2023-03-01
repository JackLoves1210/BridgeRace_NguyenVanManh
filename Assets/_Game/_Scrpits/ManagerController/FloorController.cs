using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    [SerializeField] protected GameObject _ListBrickInFloor_1;
    [SerializeField] protected GameObject _ListBrickInFloor_2;
    [SerializeField] protected GameObject _ListBrickInFloor_3;
    [SerializeField] protected int _numberFloor;
    [SerializeField] public List<GameObject> _listBrick;
    void Start()
    {
        Oninit();
    }

    private void Oninit()
    {
       ListBrick();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<GameObject> ListBrick(){
        if (_numberFloor == 1)
        {
            foreach (Transform item in _ListBrickInFloor_1.transform)
            {
                _listBrick.Add(item.gameObject);
            }
        }
        if (_numberFloor == 2)
        {
            foreach (Transform item in _ListBrickInFloor_2.transform)
            {

                _listBrick.Add(item.gameObject);
            }
        }
        if (_numberFloor == 3)
        {
            foreach (Transform item in _ListBrickInFloor_3.transform)
            {
 
                _listBrick.Add(item.gameObject);
            }
        }
        return _listBrick;
    }
}
