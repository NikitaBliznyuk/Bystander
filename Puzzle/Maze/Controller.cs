using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private GameObject currentPoint = null;
    private Draw brush;

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
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 300))
            {
                var point = hit.collider.gameObject;
                if (point.tag == "Start Point" && currentPoint == null)
                {
                    currentPoint = hit.collider.gameObject;
                }
                else if (point.tag == "Point" || point.tag == "End Point")
                {
                    if (point.GetComponent<Point>().IsNeighbour(currentPoint))
                    {
                        brush.AddLine(currentPoint.transform.localPosition, point.transform.localPosition);
                        currentPoint = point;
                    }
                }
            }
        }
    }
}
