using System.Collections.Generic;
using UnityEngine;

namespace Puzzle.Line_puzzles
{
    public class Draw : MonoBehaviour
    {
        public Material LineMaterial;

        private readonly List<Vector3> _points = new List<Vector3>();
        private readonly List<int> _triangles = new List<int>();
        private const float Width = 0.5f;
        private MeshFilter _filter;
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _filter = GetComponent<MeshFilter>();
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        public void AddLine(Vector3 startPoint, Vector3 endPoint)
        {
            var baseIndex = _points.Count;
            // Line to left
            if (startPoint.x - endPoint.x > 0)
            {
                _points.Add(new Vector3(endPoint.x - Width / 2.0f, endPoint.y + Width / 2.0f, endPoint.z));
                _points.Add(new Vector3(endPoint.x - Width / 2.0f, endPoint.y - Width / 2.0f, endPoint.z));
                _points.Add(new Vector3(startPoint.x + Width / 2.0f, startPoint.y + Width / 2.0f, startPoint.z));
                _points.Add(new Vector3(startPoint.x + Width / 2.0f, startPoint.y - Width / 2.0f, startPoint.z));
            }
            // Line to right
            else if (startPoint.x - endPoint.x < 0)
            {
                _points.Add(new Vector3(startPoint.x - Width / 2.0f, startPoint.y + Width / 2.0f, startPoint.z));
                _points.Add(new Vector3(startPoint.x - Width / 2.0f, startPoint.y - Width / 2.0f, startPoint.z));
                _points.Add(new Vector3(endPoint.x + Width / 2.0f, endPoint.y + Width / 2.0f, endPoint.z));
                _points.Add(new Vector3(endPoint.x + Width / 2.0f, endPoint.y - Width / 2.0f, endPoint.z));
            }
            //Line to up
            else if (startPoint.y - endPoint.y < 0)
            {
                _points.Add(new Vector3(startPoint.x - Width / 2.0f, startPoint.y - Width / 2.0f, startPoint.z));
                _points.Add(new Vector3(startPoint.x + Width / 2.0f, startPoint.y - Width / 2.0f, startPoint.z));
                _points.Add(new Vector3(endPoint.x - Width / 2.0f, endPoint.y + Width / 2.0f, endPoint.z));
                _points.Add(new Vector3(endPoint.x + Width / 2.0f, endPoint.y + Width / 2.0f, endPoint.z));
            }
            //Line to down
            else if (startPoint.y - endPoint.y > 0)
            {
                _points.Add(new Vector3(endPoint.x - Width / 2.0f, endPoint.y - Width / 2.0f, endPoint.z));
                _points.Add(new Vector3(endPoint.x + Width / 2.0f, endPoint.y - Width / 2.0f, endPoint.z));
                _points.Add(new Vector3(startPoint.x - Width / 2.0f, startPoint.y + Width / 2.0f, startPoint.z));
                _points.Add(new Vector3(startPoint.x + Width / 2.0f, startPoint.y + Width / 2.0f, startPoint.z));
            }
            var newTriangles = new List<int> {
                baseIndex + 2, baseIndex + 1, baseIndex + 0,
                baseIndex + 1, baseIndex + 2, baseIndex + 3 };
            _triangles.AddRange(newTriangles);

            ToDraw();
        }

        private void ToDraw()
        {
            var mesh = new Mesh()
            {
                vertices = _points.ToArray(),
                triangles = _triangles.ToArray()
            };

            _filter.mesh = mesh;
            _meshRenderer.material = LineMaterial;
        }

        public void Clear()
        {
            _points.Clear();
            _triangles.Clear();

            ToDraw();
        }
    }
}
