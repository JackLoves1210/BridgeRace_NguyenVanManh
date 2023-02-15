
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;

    private Transform _camera;

    [SerializeField] private Vector3 _offset;

    private void Awake()
    {
        _camera = this.transform;
        _offset = _camera.position - _player.position ;
    }

    private void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        _camera.position = Vector3.Lerp(_camera.position, _offset + _player.position, Time.deltaTime *_speed);
    }
}
