using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetBrick : MonoBehaviour
{
    [SerializeField] public Transform _targetPoint;
    [SerializeField] public GameObject _brickPrefab;
    [SerializeField] private GetColor _getColorCharacter;
    [SerializeField] private HolderBrick _holderBrick;
    public Stack<GameObject> _stackBrick = new Stack<GameObject>();   // tích stack trên lưng player
    private Vector3 _stack = new Vector3(0, 0.3f, 0);                  // độ cao stack gạch
    public List<GameObject> _bricks = new List<GameObject>();                // lấy ra vị trí các viên gạch đã ăn 

    public int _countBrick = 0;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Brick" )
        {
            if (other.gameObject.GetComponent<ResourceGenerator>()._number == _getColorCharacter._numColor )
            {
                AddBrick();
                other.gameObject.SetActive(false);
                _holderBrick._listObjectPooling.Add(other.transform);
            }
        }
        if (other.CompareTag("BrickCharacter"))
        {
            AddBrick();
            Destroy(other);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.collider.CompareTag("BrickCharacter"))
        {
            AddBrick();
            Debug.Log("â");
        }
    }
    private void AddBrick()
    {
        _brickPrefab.GetComponent<Renderer>().material = _getColorCharacter.gameObject.GetComponent<Renderer>().material;
        // Tạo gạch trên lưng player
        GameObject obj = Instantiate(_brickPrefab, new Vector3(_targetPoint.position.x, _targetPoint.position.y - _countBrick * _stack.y, _targetPoint.position.z), transform.rotation);
        //  obj.GetComponent<Renderer>().material = transform.GetComponent<Renderer>().material;

        _stackBrick.Push(obj);
        _targetPoint.position += _stack;
        _countBrick++;

        obj.transform.SetParent(_targetPoint);
    }

    public IEnumerator Fly(GameObject obj, Vector3 target)
    {
        while (Vector3.Distance(obj.transform.localPosition,target)<0.1f)
        {
            obj.transform.localPosition = Vector3.MoveTowards(obj.transform.localPosition, target, Time.deltaTime);
            yield return null;
        }
        yield return null;
    }

    public void RemoveBrick()
    {
        // khi va chạm với cầu sẽ trừ đi gạch trên lưng
        _countBrick--;
        _targetPoint.position -= _stack;
        _stackBrick.Pop();
        Destroy(_targetPoint.GetChild(_countBrick).gameObject);
        if (_holderBrick._listObjectPooling.Count -1 > 0)
        {
            Transform newobject = _holderBrick._listObjectPooling[_holderBrick._listObjectPooling.Count - 1];
            _holderBrick._listObjectPooling.RemoveAt(_holderBrick._listObjectPooling.Count - 1);
            newobject.SetParent(_holderBrick.transform);
            newobject.gameObject.SetActive(true);
        }
    }

    public void ResetBrick()
    {
        _countBrick = 0;
        _targetPoint.position -= _stackBrick.Count * _stack;
        _stackBrick.Clear();
        foreach (Transform child in _targetPoint)
        {
            Destroy(child.gameObject);
        }
    }
}
