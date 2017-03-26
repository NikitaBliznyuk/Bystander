using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour {
    public Material lineMaterial;

    private List<Vector3> points;
    private List<int> triangles;
    private float width = 0.5f;
    private MeshFilter filter;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        points = new List<Vector3>();
        triangles = new List<int>();
        filter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void AddLine(Vector3 startPoint, Vector3 endPoint)
    {
        var baseIndex = points.Count;
        // Line to left
        if (startPoint.x - endPoint.x > 0)
        {
            points.Add(new Vector3(endPoint.x - width / 2.0f, endPoint.y + width / 2.0f, endPoint.z));
            points.Add(new Vector3(endPoint.x - width / 2.0f, endPoint.y - width / 2.0f, endPoint.z));
            points.Add(new Vector3(startPoint.x + width / 2.0f, startPoint.y + width / 2.0f, startPoint.z));
            points.Add(new Vector3(startPoint.x + width / 2.0f, startPoint.y - width / 2.0f, startPoint.z));
        }
        // Line to right
        else if (startPoint.x - endPoint.x < 0)
        {
            points.Add(new Vector3(startPoint.x - width / 2.0f, startPoint.y + width / 2.0f, startPoint.z));
            points.Add(new Vector3(startPoint.x - width / 2.0f, startPoint.y - width / 2.0f, startPoint.z));
            points.Add(new Vector3(endPoint.x + width / 2.0f, endPoint.y + width / 2.0f, endPoint.z));
            points.Add(new Vector3(endPoint.x + width / 2.0f, endPoint.y - width / 2.0f, endPoint.z)); 
        }
        //Line to up
        else if (startPoint.y - endPoint.y < 0)
        {
            points.Add(new Vector3(startPoint.x - width / 2.0f, startPoint.y - width / 2.0f, startPoint.z));
            points.Add(new Vector3(startPoint.x + width / 2.0f, startPoint.y - width / 2.0f, startPoint.z));
            points.Add(new Vector3(endPoint.x - width / 2.0f, endPoint.y + width / 2.0f, endPoint.z));
            points.Add(new Vector3(endPoint.x + width / 2.0f, endPoint.y + width / 2.0f, endPoint.z));
        }
        //Line to down
        else if (startPoint.y - endPoint.y > 0)
        {
            points.Add(new Vector3(endPoint.x - width / 2.0f, endPoint.y - width / 2.0f, endPoint.z));
            points.Add(new Vector3(endPoint.x + width / 2.0f, endPoint.y - width / 2.0f, endPoint.z));
            points.Add(new Vector3(startPoint.x - width / 2.0f, startPoint.y + width / 2.0f, startPoint.z));
            points.Add(new Vector3(startPoint.x + width / 2.0f, startPoint.y + width / 2.0f, startPoint.z));
        }
        var newTriangles = new List<int> {
            baseIndex + 2, baseIndex + 1, baseIndex + 0,
            baseIndex + 1, baseIndex + 2, baseIndex + 3 };
        triangles.AddRange(newTriangles);

        ToDraw();
    }

    private void ToDraw()
    {
        var mesh = new Mesh()
        {
            vertices = points.ToArray(),
            triangles = triangles.ToArray()
        };
        
        filter.mesh = mesh;
        meshRenderer.material = lineMaterial;
    }
}
