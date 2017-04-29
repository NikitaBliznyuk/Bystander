using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMotor : MonoBehaviour
{
    protected CharacterController controller;
    protected Transform thisTransform;
    protected BaseState state;

    private float baseSpeed = 5.0f;
    private float baseGravity = 25.0f;
    private float baseJumpForce = 7.0f;
    private float terminalVelocity = 30.0f;
    private float groundRayDistance = 0.5f;
    private float groundRayInnerOffset = 0.1f;

    public float Speed { get { return baseSpeed; } }
    public float Gravity { get { return baseGravity; } }
    public float TerminalVelocity { get { return terminalVelocity; } }
    public float JumpForce { get { return baseJumpForce; } }

    public float VerticalVelocity { set; get; }
    public Vector3 MoveVector { set; get; }
    public Quaternion RotationQuaternion { set; get; }

    protected abstract void UpdateMotor();

    protected virtual void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        thisTransform = transform;

        state = gameObject.AddComponent<WalkingState>();
        state.Construct();
    }

    private void Update()
    {
        UpdateMotor();
    }

    protected virtual void Move()
    {
        controller.Move(MoveVector * Time.deltaTime);
    }

    protected virtual void Rotate()
    {
        thisTransform.rotation = RotationQuaternion;
    }

    public virtual bool Grounded()
    {
        RaycastHit hit;
        Vector3 ray;

        float yRay = controller.bounds.center.y - controller.bounds.extents.y + 0.3f;
        float centerX = controller.bounds.center.x, centerZ = controller.bounds.center.z;
        float extentX = controller.bounds.extents.x - groundRayInnerOffset,
            extentZ = controller.bounds.extents.z - groundRayInnerOffset;

        // Middle Raycast
        ray = new Vector3(centerX, yRay, centerZ);
        if (Physics.Raycast(ray, Vector3.down, out hit, groundRayDistance))
        {
            return true;
        }

        // Side Raycasts
        for (int i = -1; i <= 1; i += 2)
        {
            for (int j = -1; j <= 1; j += 2)
            {
                ray = new Vector3(centerX + i * extentX, yRay, centerZ + j * extentZ);
                if (Physics.Raycast(ray, Vector3.down, out hit, groundRayDistance))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void ChangeState(string stateName)
    {
        System.Type type = System.Type.GetType(stateName);

        state.Destruct();
        state = gameObject.AddComponent(type) as BaseState;
        state.Construct();
    }
}
