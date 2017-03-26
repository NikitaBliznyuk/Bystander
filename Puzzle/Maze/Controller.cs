using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public bool IsSolved { get { return solved; } }

    private GameObject startPoint = null;
    private GameObject currentPoint = null;
    private Draw brush;

    private bool solved = false;

    private void Start()
    {
        brush = GetComponent<Draw>();
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0) && !solved)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 300))
            {
                HandlePoint(hit.collider.gameObject);
            }
        }
        else if(Input.GetMouseButtonDown(1))
        {
            brush.Clear();
            startPoint.transform.GetChild(0).gameObject.SetActive(false);
            startPoint = null;
            currentPoint = null;

            solved = false;
        }
    }

    public void HandlePoint(GameObject point)
    {
        if (point.tag == "Start Point" && currentPoint == null)
        {
            startPoint = point;
            currentPoint = startPoint;
            point.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (point.tag == "Point" || point.tag == "End Point")
        {
            if (point.GetComponent<Point>().IsNeighbour(currentPoint))
            {
                brush.AddLine(currentPoint.transform.localPosition, point.transform.localPosition);
                currentPoint = point;
            }

            if (point.tag == "End Point")
            {
                Debug.Log("Congratz!");
                solved = true;
            }
        }
    }
}
