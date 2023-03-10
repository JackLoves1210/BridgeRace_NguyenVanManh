using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] public AnimationController _animatorController;
    protected float _rotateSpeed;
    protected float _moveSpeed;

    protected virtual void Start()
    {
        Oninit();
    }

    protected virtual void Oninit()
    {
        _rotateSpeed = 3f;
        _moveSpeed = 4f;
    }

    public virtual void Move()
    {

    }
    public virtual void StopMoveToForward()
    {
        _moveSpeed = 0f;
    }
    public virtual void ActiveSpeed()
    {
        _moveSpeed = 4f;
    }
}
