using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToBrickState : IState<Character>
{
    public void OnEnter(Character t)
    {
    }

    public void OnExecute(Character t)
    {
      
       // t.ActiveSpeed();
        t.GoToTargetPoint();
        //t.BotBuildBrigde();
    }

    public void OnExit(Character t)
    {

    }

}
