using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : BaseState
{
    public override Vector3 ProcessMotion(Vector3 input)
    {
        ApplySpeed(ref input, motor.Speed);

        return input;
    }

    public override Quaternion ProcessRotation(Vector3 input)
    {
        if (input != Vector3.zero)
            return Quaternion.FromToRotation(Vector3.forward, input);
        else
            return base.ProcessRotation(input);
    }

    public override void Construct()
    {
        base.Construct();

        motor.VerticalVelocity = 0.0f;
    }

    public override void Transition()
    {
        if (!motor.Grounded())
            motor.ChangeState("FallingState");

        if (Input.GetKeyDown(KeyCode.E))
            motor.ChangeState("SolvingState");
    }
}
