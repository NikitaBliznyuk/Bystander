using UnityEngine;

public class PauseState : BaseState
{
    private PauseMenuController controller;

    public override void Construct()
    {
        base.Construct();

        controller = FindObjectOfType<PauseMenuController>();
    }

    public override Vector3 ProcessMotion(Vector3 input)
    {
        return Vector3.zero;
    }

    public override void Transition()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || !controller.IsEnabled)
            motor.ChangeState("WalkingState");
    }
}
