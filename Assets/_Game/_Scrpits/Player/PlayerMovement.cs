using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public FloatingJoystick _joystick;
    [SerializeField] public AnimationController _animatorController;

    [SerializeField] public float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private Rigidbody _rigidbody;

    public Vector3 _moveVector;


    private void Awake()
    {
        _rigidbody =  GetComponent<Rigidbody>();
        Oninit();
      //  _joystick = FindObjectOfType<>();
    }


    private void Update()
    {
        Move();
    }

    protected  void Oninit()
    {
        _rotateSpeed = 3f;
        _moveSpeed = 6f;
    }

    public  void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = _joystick.Horizontal * _moveSpeed * Time.deltaTime;
        _moveVector.z = _joystick.Vertical * _moveSpeed * Time.deltaTime;

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector,_rotateSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);

            _animatorController.PlayRun();
        }
        else if (_joystick.Horizontal == 0 && _joystick.Vertical == 0)
        {
            _animatorController.PlayIdle();
        }

        _rigidbody.MovePosition(_rigidbody.position + _moveVector);
    }
    public void StopMoveToForward()
    {
        _moveSpeed = 0.1f;
    }
    public void ActiveSpeed()
    {

        _moveSpeed = 6f;
    }

}
