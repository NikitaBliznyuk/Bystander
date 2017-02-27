using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour {
    public float minimuxY = -60.0f;
    public float maximumY = 60.0f;

    public float sensitivity = 15.0f;

    private float rotationY = 0.0f;

	void Update () {
        Rotate();
	}

    private void Rotate()
    {
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;

        rotationY += Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, minimuxY, maximumY);

        Camera.main.transform.localEulerAngles = new Vector3(-rotationY, 0.0f, 0.0f);
        transform.localEulerAngles = new Vector3(0.0f, rotationX, 0.0f);
    }
}
