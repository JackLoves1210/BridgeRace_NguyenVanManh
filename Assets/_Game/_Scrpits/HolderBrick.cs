using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderBrick : MonoBehaviour
{
    [SerializeField] private Transform _listBrick_1;
    [SerializeField] private Transform _listBrick_2;
    [SerializeField] private Transform _listBrick_3;

    [SerializeField] public List<Transform> _listHolderBrick;

    [SerializeField] public List<Transform> _listObjectPooling;

    void Start()
    {
        GetBrickToHolder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetBrickToHolder()
    {
        foreach (Transform child in _listBrick_1)
        {
            _listHolderBrick.Add(child);
        }
        foreach (Transform child in _listBrick_2)
        {
            _listHolderBrick.Add(child);
        }
        foreach (Transform child in _listBrick_3)
        {
            _listHolderBrick.Add(child);
        }
    }
}
