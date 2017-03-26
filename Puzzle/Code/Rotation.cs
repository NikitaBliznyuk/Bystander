using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Code
{
    public class Rotation : MonoBehaviour
    {
        public Numbers Number { get; private set; }

        private float speed;

        private float endAngle;

        private bool inRotation;

        private int sign; // to rotate in different directions

        private readonly float rotationAngle = 36.0f;

        private void Start()
        {
            endAngle = Mathf.Round(transform.rotation.eulerAngles.z);

            Number = (Numbers)(endAngle / rotationAngle + 5);

            if (Number > Numbers.Nine)
                Number -= Enum.GetNames(typeof(Numbers)).Length;

            speed = 5.0f;

            sign = 1;

            inRotation = false;
        }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            if (!inRotation)
            {
                CheckInput();
            }
            else
            {
                SmoothRotate();
            }
        }

        private void CheckInput()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                if (Input.GetMouseButtonDown(0))
                    sign = 1;
                else if (Input.GetMouseButtonDown(1))
                    sign = -1;
                else
                    return;

                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 300))
                {
                    if (hit.collider.gameObject == gameObject && !inRotation)
                    {
                        endAngle = transform.rotation.eulerAngles.z + rotationAngle * sign;

                        inRotation = true;

                        if (endAngle > 360.0f)
                            endAngle -= 360.0f;
                        else if (endAngle < 0.0f)
                            endAngle += 360.0f;
                    }
                }
            }
        }

        private void SmoothRotate()
        {
            float rotation = transform.rotation.eulerAngles.z;

            float angle = Mathf.LerpAngle(0, rotationAngle, Time.deltaTime * speed);

            angle = Mathf.Clamp(angle, 0, Mathf.Abs(endAngle - rotation));

            transform.Rotate(0.0f, 0.0f, angle * sign);

            if ((int)Mathf.Abs(rotation + angle - endAngle) == 0)
            {
                inRotation = false;

                Number += sign;
                if (Number > Numbers.Nine)
                    Number = Numbers.Zero;
                else if (Number < Numbers.Zero)
                    Number = Numbers.Nine;
            }

        }
    }
}
