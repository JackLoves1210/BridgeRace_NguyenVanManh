using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Character>
{
    float timer;
    float randomTime;
    public void OnEnter(Character t)
    {
        t.StopMoveToForward();
        timer = 0;
        randomTime = Random.Range(0.5f, 1.5f);
    }

    public void OnExecute(Character t)
    {
        timer += Time.deltaTime;
        if (timer > randomTime)
        {
            t.ChangeState(new MoveToBrickState());
        }
    }

    public void OnExit(Character t)
    {

    }

}
