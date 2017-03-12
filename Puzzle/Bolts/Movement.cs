using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bolts
{
    public class Movement : MonoBehaviour
    {
        public Transform rightBoard;
        public Transform[] items;

        private Vector3 screenSpace;
        private Vector3 offset;
        private readonly float staticRightBoard = 2.121f;
        private readonly float staticLeftBoard = -3.321f;
        private float rightBoardPosition;
        private float leftBoardPosition;
        private readonly float boardStep = 0.63f;
        private bool isGrab = false;

        private void Start()
        {
            rightBoardPosition = transform.position.x + staticRightBoard;
            leftBoardPosition = transform.position.x + staticLeftBoard;
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
                            screenSpace = Camera.main.WorldToScreenPoint(transform.position);
                            offset = transform.position -
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
                var currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;

                var boardValue = GetBoard();
                var boardOffset = rightBoard.position.x - transform.position.x;

                Mathf.Clamp(currentPosition.x, );

                if (currentPosition.x + boardOffset <= boardValue)
                    transform.position = new Vector3(currentPosition.x, transform.position.y, transform.position.z);
                else
                    transform.position = new Vector3(boardValue - boardOffset, transform.position.y, transform.position.z);
            }
        }

        private float GetBoard()
        {
            var board = rightBoardPosition;
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
