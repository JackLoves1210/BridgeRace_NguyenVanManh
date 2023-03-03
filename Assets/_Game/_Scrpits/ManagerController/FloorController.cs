using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    [SerializeField] protected GameObject _ListBrickInFloor_1;
    [SerializeField] protected GameObject _ListBrickInFloor_2;
    [SerializeField] protected GameObject _ListBrickInFloor_3;
    [SerializeField] public int _numberFloor;
    [SerializeField] public List<Transform> _listBrick;

    void Start()
    {
        Oninit();
    }

    private void Oninit()
    {
       ListBrick(_numberFloor);
    }

    // Update is called once per frame


    public List<Transform> ListBrick(int num){
        if (num == 1)
        {
            foreach (Transform item in _ListBrickInFloor_1.transform)
            {
                
                _listBrick.Add(item);
            }
        }
        if (num == 2)
        {
            foreach (Transform item in _ListBrickInFloor_2.transform)
            {
                
                _listBrick.Clear();
                _listBrick.Add(item);
            }
        }
        if (num == 3)
        {
            foreach (Transform item in _ListBrickInFloor_3.transform)
            {
                
                _listBrick.Clear();
                _listBrick.Add(item);
            }
        }
        return _listBrick;
    }
}
