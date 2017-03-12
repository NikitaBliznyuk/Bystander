using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bolts
{
    public class Movement : MonoBehaviour
    {
        public Transform rightBoard;
        public Transform leftBoard;
        public Transform staticRightBoard;
        public Transform staticLeftBoard;
        public Transform[] items;

        private Vector3 screenSpace;
        private Vector3 offset;
        public float boardOffset;
        private readonly float boardStep = 0.63f;
        private bool isGrab = false;

        public Vector3 currentPosition;

        private void Start()
        {
            boardOffset = rightBoard.localPosition.x - transform.localPosition.x;
        }

        private void Update()
        {
            CheckInput();
            Move();
        }

        private void CheckInput()
        {
            if (Input.GetMouseButton(0))
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
            }
            else
            {
                isGrab = false;
            }
        }

        private void Move()
        {
            if (isGrab)
            {
                var currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
                currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;

                var rightBoardValue = GetBoard();

                currentPosition.x = Mathf.Clamp(currentPosition.x, staticLeftBoard.localPosition.x + boardOffset, rightBoardValue - boardOffset);
                transform.localPosition = new Vector3(currentPosition.x, transform.localPosition.y, transform.localPosition.z);
            }
        }

        private float GetBoard()
        {
            var board = staticRightBoard.position.x;
            for(int i=0;i<items.Length;i++)
            {
                if (items[i].GetComponent<Rotation>().rotated)
                {
                    board += boardStep;
                }
                else break;
            }
            return board;
        }
    }
}
