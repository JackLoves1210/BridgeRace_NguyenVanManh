using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetBrick : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;
    [SerializeField] public GameObject _brickPrefab;
    [SerializeField] private GetColor _getColorCharacter;
    //[SerializeField] public GameObject _brick;
    public Stack<GameObject> _stackBrick = new Stack<GameObject>();   // tích stack trên lưng player
    private Vector3 _stack = new Vector3(0, 0.25f, 0);                  // độ cao stack gạch
    public List<GameObject> _bricks = new List<GameObject>();                // lấy ra vị trí các viên gạch đã ăn 
    //[SerializeField] private BrickManagerment _brickManagerment;

    public int _countBrick = 0;

    private void Start()
    {
        //_brickManagerment = _brickManagerment.GetComponent<BrickManagerment>();
    }
    private void Update()
    {
       // Debug.Log("Count brick :" + _countBrick);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Brick")
        {
            if (other.gameObject.GetComponent<ResourceGenerator>()._number == _getColorCharacter._numColor)
            {
                AddBrick();
                int num = other.gameObject.GetComponent<ResourceGenerator>()._number;
             //s   BrickManagerment.arr1[num]--;
              //  _brickManagerment.arr1[num]--;
                //  Destroy(other.gameObject);
                _bricks.Add(other.gameObject);
                other.gameObject.SetActive(false);
            }
        }
        
    }
    private void AddBrick()
    {
        _brickPrefab.GetComponent<Renderer>().material = _getColorCharacter.gameObject.GetComponent<Renderer>().material;
        // Tạo gạch trên lưng player
        GameObject obj =  Instantiate(_brickPrefab, new Vector3(_targetPoint.position.x , _targetPoint.position.y - _countBrick * _stack.y, _targetPoint.position.z), transform.rotation);
     //  obj.GetComponent<Renderer>().material = transform.GetComponent<Renderer>().material;
        _stackBrick.Push(obj);
        _targetPoint.position += _stack;
        _countBrick++;
        obj.transform.SetParent(_targetPoint);
    }

    public void RemoveBrick()
    {
        // khi va chạm với cầu sẽ trừ đi gạch trên lưng
        _countBrick--;
        _targetPoint.position -= _stack;
       // Debug.Log("countBrick :" + _countBrick);
        _stackBrick.Pop();
        Destroy(_targetPoint.GetChild(_countBrick).gameObject);
        _bricks[_bricks.Count-1].SetActive(true);
        _bricks.RemoveAt(_bricks.Count - 1);
    }
}
