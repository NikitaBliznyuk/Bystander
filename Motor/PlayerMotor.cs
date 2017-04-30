using UnityEngine;

public class PlayerMotor : BaseMotor
{
    private CameraMotor cameraMotor;
    private Transform cameraTransform;

    protected override void Start()
    {
        base.Start();

        cameraMotor = gameObject.AddComponent<CameraMotor>();
        cameraMotor.Init();
        cameraTransform = cameraMotor.CameraContainer;
    }

    protected override void UpdateMotor()
    {
        // Gets the input
        MoveVector = InputDirection();

        // Rotate MoveVector with Camera's forward
        MoveVector = RotateWithView(MoveVector);

        // Send input to a filter
        MoveVector = state.ProcessMotion(MoveVector);
        RotationQuaternion = state.ProcessRotation(MoveVector);

        // Check if we need to change current state
        state.Transition();

        // Move
        Move();
        Rotate();
    }

    private Vector3 InputDirection()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        direction = direction.magnitude > 1 ? direction.normalized : direction;

        return direction;
    }

    private Vector3 RotateWithView(Vector3 input)
    {
        Vector3 direction = cameraTransform.TransformDirection(input);
        direction.y = 0.0f;
        return direction.normalized * input.magnitude;
    }

    public override void ChangeState(string stateName)
    {
        base.ChangeState(stateName);

        cameraMotor.enabled = stateName != "SolvingState" && stateName != "PauseState";
    }
}
