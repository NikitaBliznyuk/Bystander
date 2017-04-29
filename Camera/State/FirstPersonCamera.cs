using UnityEngine;

public class FirstPersonCamera : BaseCameraState
{
    private const float Y_ANGLE_MIN = -75.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    private float offset = 1.0f;

    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensivityX = 10.0f;
    private float sensivityY = 3.0f;

    public override Vector3 ProcessMotion(Vector3 input)
    {
        return transform.position + transform.up * offset;
    }

    public override Quaternion ProcessRotation(Vector3 input)
    {
        currentX += input.x * sensivityX;
        currentY += input.z * sensivityY;

        // Clamp my current Y
        currentY = ClampAngle(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

        return Quaternion.Euler(currentY, currentX, 0.0f);
    }
}
