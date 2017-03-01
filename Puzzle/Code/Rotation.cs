using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class Rotation : MonoBehaviour
    {
        public char Number { get; private set; }

        private float speed = 5.0f;

        private float startAngle = 0.0f;
        private float endAngle = 0.0f;

        private bool inRotation = false;

        private int sign = 1;

        private void Start()
        {
            Number = '5';
        }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 300))
            {
                if (hit.collider.gameObject == gameObject && !inRotation)
                {
                    if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            endAngle += 36.0f;
                            Number++;
                            sign = 1;
                        }
                        else if(Input.GetMouseButtonDown(1))
                        {
                            endAngle -= 36.0f;
                            Number--;
                            sign = -1;
                        }

                        inRotation = true;

                        if (endAngle >= 360.0f)
                            endAngle -= 360.0f;
                        else if (endAngle < 0.0f)
                            endAngle = 324.0f;

                        if (Number > '9')
                            Number = '0';
                        else if (Number < '0')
                            Number = '9';
                    }
                }
            }

            float rotation = transform.rotation.eulerAngles.z;

            if (Mathf.Abs(endAngle - rotation) > (speed / 2.0f))
            {
                float angle = Mathf.LerpAngle(startAngle, startAngle + 36, Time.deltaTime * speed);

                transform.Rotate(0.0f, 0.0f, angle * sign);
            }
            else
            {
                startAngle = 0.0f;
                inRotation = false;
                transform.Rotate(0.0f, 0.0f, endAngle - rotation);
            }
        }
    }
}
