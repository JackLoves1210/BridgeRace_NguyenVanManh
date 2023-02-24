using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBridge : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _step;
    [SerializeField] private Transform _brigde;
    [SerializeField] private LayerMask _BRIDGE_LAYER;
    //  [SerializeField] private GameObject _box;
    [SerializeField] private GetColor _getColorCharacter;
    [SerializeField] private PlayerGetBrick _playerGetBrick;

    private int _numberBrick;
    private void Start()
    {
        _playerGetBrick = _playerGetBrick.GetComponent<PlayerGetBrick>();
    }

    private bool _isHaveStep;
    private void Update()
    {
        _numberBrick = _playerGetBrick.GetComponent<PlayerGetBrick>()._stackBrick.Count;
        BuildStair();
    }
    private void BuildStair()
    {
        Debug.DrawLine(_player.position + new Vector3(0, 1f, 0.25f), _player.position + new Vector3(0, 0, 0.25f) + Vector3.down * 50f, color: Color.red);
        Ray ray = new Ray(_player.position + new Vector3(0, 1f, 0.25f), Vector3.down);
        RaycastHit hit;
        bool isHit = Physics.Raycast(ray, out hit, 50f,_BRIDGE_LAYER);

        // hit2 check phia trc co gach ko
        Debug.DrawLine(_player.position + new Vector3(0, 2f, 1f), _player.position + new Vector3(0, 0, 0.25f) + Vector3.down * 50f, Color.blue);
        RaycastHit hit_1;
        Ray ray_1 = new Ray(_player.position + new Vector3(0, 2f, 1f), Vector3.down);
        bool isHit_1 = Physics.Raycast(ray_1, out hit_1, 50f, _BRIDGE_LAYER);
        if (isHit_1)
        {
            if (hit_1.collider != null && hit_1.collider.tag == "Stair")
            {
                _isHaveStep = true;
            }
            else _isHaveStep = false;
        }
        if (isHit && !_isHaveStep)
        {
            if (hit.collider != null && hit.collider.tag == "Stair")
            {
                _isHaveStep = true;
                //Debug.Log("Not spawn");
            }
            
            if (hit.collider != null && !_isHaveStep && _numberBrick > 0)
            {
                _isHaveStep = false;
                _step.GetComponent<GetColor>()._numColor = _getColorCharacter.gameObject.GetComponent<GetColor>()._numColor;
                GameObject obj = Instantiate(_step, new Vector3(hit.collider.transform.position.x,hit.point.y+0.25f,hit.point.z + 0.45f) , Quaternion.identity);
                _playerGetBrick.RemoveBrick();
                obj.gameObject.transform.SetParent(_brigde);
            }
            else if (hit.collider != null && _numberBrick <= 0 && _player.GetComponent<PlayerMovement>()._moveVector.z >0 && transform.CompareTag("Player"))
            {
                _player.GetComponent<PlayerMovement>().StopMoveToForward();
            }
            else if (hit.collider != null && _numberBrick <= 0 && _player.GetComponent<PlayerMovement>()._moveVector.z < 0 && transform.CompareTag("Player"))
            {
                _player.GetComponent<PlayerMovement>().ActiveSpeed();
            }

        }
        else if(hit.collider != null && _isHaveStep && _numberBrick > 0)
        {
            if (hit.collider.GetComponent<GetColor>()._numColor != _getColorCharacter.gameObject.GetComponent<GetColor>()._numColor)
            {
                hit.collider.GetComponent<GetColor>()._numColor = _getColorCharacter.gameObject.GetComponent<GetColor>()._numColor;
                hit.collider.GetComponent<Renderer>().material = _getColorCharacter.gameObject.GetComponent<Renderer>().material;
                _playerGetBrick.RemoveBrick();
            }
            
        }
    }
}
