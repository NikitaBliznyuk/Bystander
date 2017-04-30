using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : BaseState
{
    public override Vector3 ProcessMotion(Vector3 input)
    {
        return Vector3.zero;
    }

    public override void Transition()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            motor.ChangeState("WalkingState");
    }
}
