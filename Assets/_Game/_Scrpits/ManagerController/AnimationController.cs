using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private string _currentAnim;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayIdle()
    {
        ChangeAnim("idle");
    }
    public void PlayRun()
    {
        ChangeAnim("run");
    }

    public void PlayWin()
    {
        ChangeAnim("win");
    }
    private void ChangeAnim(string _animName)
    {
        if (_currentAnim != _animName)
        {
            _animator.ResetTrigger(_animName);
            _currentAnim = _animName;
            _animator.SetTrigger(_currentAnim);
        }
    }
}
