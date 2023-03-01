using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveBrick : MonoBehaviour
{
    [SerializeField] private GameObject _colorPlayer;
    [SerializeField] private Transform _player;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private LayerMask _BRIDGE_LAYER;
    [Range(0, 1)] public float lertTime;

    [SerializeField] Color color;

    [SerializeField] private PlayerGetBrick _playerGetBrick;

    private int _numberBrick;
    private void Start()
    {
        Oninit();
        _playerGetBrick = _playerGetBrick.GetComponent<PlayerGetBrick>();
    }

    private bool _isHaveStep;
    private void Update()
    {
        _numberBrick = _playerGetBrick.GetComponent<PlayerGetBrick>()._stackBrick.Count;
        StopMove();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(_numberBrick);
        if (other.CompareTag("Player"))
        {
            color = _colorPlayer.GetComponent<Renderer>().material.color;
            if (_numberBrick > 0)
            {
                ChangeColor();
            }
            //if (_numberBrick <= 0 && _player.GetComponent<PlayerMovement>()._moveVector.z > 0 && other.CompareTag("Player"))
            //{
            //    _player.GetComponent<PlayerMovement>().StopMoveToForward();
            //    Debug.Log("Stop move");
            //}
            //else if (_numberBrick <= 0 && _player.GetComponent<PlayerMovement>()._moveVector.z < 0 && transform.CompareTag("Player"))
            //{
            //    _player.GetComponent<PlayerMovement>().ActiveSpeed();
            //}
        }
    }

    private void Oninit()
    {
        _renderer = GetComponent<MeshRenderer>();
    }
    private void ChangeColor()
    {
        Debug.Log("color is change");
        _renderer.material.color = Color.Lerp(_renderer.material.color, color, 1f);
        _playerGetBrick.RemoveBrick();
    }

    void StopMove()
    {
        Debug.DrawLine(_player.position + new Vector3(0, 2f, 1f), _player.position + new Vector3(0, 0, 0.25f) + Vector3.down * 50f, Color.blue);
        RaycastHit hit_1;
        
        Ray ray_1 = new Ray(_player.position + new Vector3(0, 2f, 1f), Vector3.down);


        bool isHit_1 = Physics.Raycast(ray_1, out hit_1, 50f, _BRIDGE_LAYER);
        if (isHit_1)
        {
            Debug.Log(hit_1);
            if (hit_1.collider != null && hit_1.collider.tag != "Stair" && _numberBrick <= 0 && _player.GetComponent<PlayerMovement>()._moveVector.z > 0 && transform.CompareTag("Player")) 
            {
                _player.GetComponent<PlayerMovement>().StopMoveToForward();
                Debug.Log("Stop move");
            }
            else if (_numberBrick <= 0 && _player.GetComponent<PlayerMovement>()._moveVector.z < 0 && transform.CompareTag("Player"))
            {
                _player.GetComponent<PlayerMovement>().ActiveSpeed();
            }
        }   
    }
}
