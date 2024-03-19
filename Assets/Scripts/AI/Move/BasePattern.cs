using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePattern
{
    public bool isOver = false;

    public abstract void OnUpdate();

    public abstract void Enter(AIAgent agent);
    public abstract void Update(AIAgent agent);
    public abstract void Exit(AIAgent agent);
    public abstract void SelectPattern();


}
