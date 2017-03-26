using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour {
    public float moveSpeed = 5.0f;
    private Rigidbody m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update ()
    {
        Move();
        
	}

    private void Move()
    {
        Vector3 movement = Vector3.zero;

        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        movement = movement.magnitude > 1 ? movement.normalized : movement;

        transform.Translate(movement * Time.deltaTime * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_Rigidbody.drag = Mathf.Infinity;
    }

    private void OnCollisionExit(Collision collision)
    {
        m_Rigidbody.drag = 0.5f;
    }
}
