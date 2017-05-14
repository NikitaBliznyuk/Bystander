using System.Collections.Generic;
using UnityEngine;

namespace Puzzle.Line_puzzles.Maze
{
    public class Controller : BaseController
    {
        public Point[] WinPath;

        private GameObject _startPoint;
        private GameObject _currentPoint;
        private Draw _brush;
        private List<Point> _pathOfPoints;

        private void Start()
        {
            _brush = GetComponent<Draw>();
            _pathOfPoints = new List<Point>();

            Load();

            if(PuzzleSolved)
            {
                ShowWinPath();
            }
        }

        private void ShowWinPath()
        {
            var startPoint = WinPath[0];
            startPoint.TurnBacklight(true);
            startPoint.IsBusy = true;

            for(var i = 1; i < WinPath.Length; i++)
            {
                WinPath[i].TurnBacklight(true);
                WinPath[i].IsBusy = true;
                _brush.AddLine(startPoint.transform.localPosition, WinPath[i].transform.localPosition);
                startPoint = WinPath[i];
            }
        }

        protected override void Update()
        {
            GetInput();
        }

        private void GetInput()
        {
            if (Input.GetMouseButtonDown(0) && !PuzzleSolved)
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 300))
                {
                    HandlePoint(hit.collider.gameObject);
                }
            }
            else if(!PuzzleSolved && Input.GetMouseButtonDown(1))
            {
                ResetPuzzle();
            }
        }

        public void HandlePoint(GameObject point)
        {
            if (point.CompareTag("Start Point") && _currentPoint == null)
            {
                _pathOfPoints.Add(point.GetComponent<Point>());
                point.GetComponent<Point>().IsBusy = true;

                _startPoint = point;
                _currentPoint = _startPoint;
                point.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (point.CompareTag("Point") || point.CompareTag("End Point"))
            {
                if (!point.GetComponent<Point>().IsNeighbour(_currentPoint)) return;
                _pathOfPoints.Add(point.GetComponent<Point>());
                _brush.AddLine(_currentPoint.transform.localPosition, point.transform.localPosition);
                _currentPoint = point;

                if (!point.CompareTag("End Point")) return;
                Debug.Log("Congratz!");
                PuzzleSolved = true;
            }
        }

        private void ResetPuzzle()
        {
            _brush.Clear();

            foreach (var point in _pathOfPoints)
                point.IsBusy = false;
            _pathOfPoints.Clear();

            if(_startPoint != null)
                _startPoint.transform.GetChild(0).gameObject.SetActive(false);
            _startPoint = null;
            _currentPoint = null;

            PuzzleSolved = false;
        }
    }
}
