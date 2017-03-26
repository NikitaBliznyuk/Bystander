using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 screenSpace;
    private Vector3 offset;

    private bool isGrab = false;

    private void Update()
    {
        CheckInput();
        Move();
    }

    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isGrab)
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 300))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        screenSpace = Camera.main.WorldToScreenPoint(transform.localPosition);
                        offset = transform.localPosition -
                            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
                        isGrab = true;
                    }
                }
            }
            else
            {
                isGrab = false;
            }
        }
    }

    private void Move()
    {
        if (isGrab)
        {
            var currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
            var currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;

            transform.localPosition = new Vector3(currentPosition.x, currentPosition.y, 0.0f);
        }
    }
}
