using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetBrick : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private GameObject _brickPrefab;

    private Stack<GameObject> _stackBrick = new Stack<GameObject>();
    private Vector3 _stack = new Vector3(0, 0.25f, 0);

    int _countBrick = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Brick")
        {
            Debug.Log(other.gameObject.GetComponent<Renderer>().material.name);
            if (other.gameObject.GetComponent<Renderer>().material.name.Equals( ResourceManager._instance._resources[0]._material.name))
            {
                Debug.Log("a");
                AddBrick();
                Destroy(other.gameObject);
            }
            
        }
        
    }
    private void AddBrick()
    {
        GameObject obj =  Instantiate(_brickPrefab, new Vector3(_targetPoint.position.x , _targetPoint.position.y - _countBrick * _stack.y, _targetPoint.position.z), transform.rotation);
        _stackBrick.Push(obj);
        _targetPoint.position += _stack;
        _countBrick++;
        obj.transform.SetParent(_targetPoint);
    }
}
