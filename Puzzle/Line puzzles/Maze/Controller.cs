using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour, ISolved
{
    private GameObject startPoint = null;
    private GameObject currentPoint = null;
    private Draw brush;
    private List<Point> pathOfPoints;

    private bool solved = false;

    private void Start()
    {
        brush = GetComponent<Draw>();
        pathOfPoints = new List<Point>();
    }

    protected virtual void Update()
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
        else if(!solved && Input.GetMouseButtonDown(1))
        {
            ResetPuzzle();
        }
    }

    public void HandlePoint(GameObject point)
    {
        if (point.tag == "Start Point" && currentPoint == null)
        {
            pathOfPoints.Add(point.GetComponent<Point>());
            point.GetComponent<Point>().IsBusy = true;

            startPoint = point;
            currentPoint = startPoint;
            point.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (point.tag == "Point" || point.tag == "End Point")
        {
            if (point.GetComponent<Point>().IsNeighbour(currentPoint))
            {
                pathOfPoints.Add(point.GetComponent<Point>());
                brush.AddLine(currentPoint.transform.localPosition, point.transform.localPosition);
                currentPoint = point;

                if (point.tag == "End Point")
                {
                    Debug.Log("Congratz!");
                    solved = true;
                }
            }
        }
    }

    private void ResetPuzzle()
    {
        brush.Clear();

        foreach (var point in pathOfPoints)
            point.IsBusy = false;
        pathOfPoints.Clear();

        if(startPoint != null)
            startPoint.transform.GetChild(0).gameObject.SetActive(false);
        startPoint = null;
        currentPoint = null;

        solved = false;
    }

    bool ISolved.IsSolved()
    {
        return solved;
    }
}
