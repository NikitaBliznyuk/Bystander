﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour {
    private List<Vector3> points;
    private List<int> triangles;
    private float width = 0.5f;
    private MeshFilter filter;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        filter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void AddLine(Vector3 startPoint, Vector3 endPoint)
    {
        var baseIndex = points.Count;
        // Line to left
        if (startPoint.x - endPoint.x > 0)
        {
            points.Add(new Vector3(startPoint.x + width / 2.0f, startPoint.y + width / 2.0f, startPoint.z));
            points.Add(new Vector3(startPoint.x + width / 2.0f, startPoint.y - width / 2.0f, startPoint.z));
            points.Add(new Vector3(endPoint.x - width / 2.0f, endPoint.y + width / 2.0f, endPoint.z));
            points.Add(new Vector3(endPoint.x - width / 2.0f, endPoint.y - width / 2.0f, endPoint.z));
        }
        var newTriangles = new List<int> {
            baseIndex, baseIndex + 1, baseIndex + 2,
            baseIndex + 1, baseIndex + 2, baseIndex + 3 };
        triangles.AddRange(newTriangles);

        ToDraw();
    }

    private void ToDraw()
    {
        var mesh = new Mesh();
        mesh.vertices = points.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        filter.mesh = mesh;
    }
}