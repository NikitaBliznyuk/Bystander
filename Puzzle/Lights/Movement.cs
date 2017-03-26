using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lights
{
    public class Movement : MonoBehaviour
    {
        public Transform startPosition;

        private Vector3 screenSpace;
        private Vector3 offset;

        private readonly float jumpSize = 0.3f;

        private bool isGrab = false;

        private LightController controller;

        private void Start()
        {
            controller = GetComponent<LightController>();
        }

        private void Update()
        {
            CheckInput();
            Move();
        }

        private void CheckInput()
        {
            if (Input.GetMouseButtonUp(0) && isGrab)
            {
                transform.localPosition += new Vector3(0.0f, 0.0f, jumpSize);
                isGrab = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (!isGrab)
                {
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 300, LayerMask.GetMask("Level 1")))
                    {
                        if (hit.collider.gameObject == gameObject)
                        {
                            screenSpace = Camera.main.WorldToScreenPoint(transform.localPosition);
                            offset = transform.localPosition -
                                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
                            isGrab = true;

                            controller.TurnLight(false);
                        }
                    }
                }
            }
        }

        private void Move()
        {
            if (isGrab)
            {
                var currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
                var currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;

                currentPosition.z -= jumpSize;

                transform.localPosition = currentPosition;
            }
            else
            {
                if(!controller.IsPlaced)
                {
                    transform.position = startPosition.position;
                }
            }
        }
    }
}
