using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBrigeState : IState<Character>
{
    public void OnEnter(Character t)
    {

    }

    public void OnExecute(Character t)
    {
        t.Move();
    }

    public void OnExit(Character t)
    {

    }
}
