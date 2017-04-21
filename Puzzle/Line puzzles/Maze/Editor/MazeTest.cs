using UnityEngine;
using NUnit.Framework;

public class MazeTest
{
    private GameObject maze;

    [SetUp]
    public void Init()
    {
        maze = new GameObject();
        maze.AddComponent<Draw>();
        maze.AddComponent<Controller>();
        maze.AddComponent<MeshFilter>();
        maze.AddComponent<MeshRenderer>();
        maze.GetComponent<Draw>().Start();
    }

    [Test]
    public void DrawingTest()
    {
        var brush = maze.GetComponent<Draw>();
        brush.AddLine(new Vector3(0, 0, 0), new Vector3(1, 0, 0));
        Assert.AreEqual(2, brush.GetComponent<MeshFilter>().sharedMesh.triangles[0]);
    }

    [Test]
    public void EndPuzzleTest()
    {
        var endPoint = new GameObject();
        endPoint.AddComponent<Point>();
        endPoint.GetComponent<Point>().neighbours = new GameObject[] { };
        endPoint.tag = "End Point";

        var controller = maze.GetComponent<Controller>();
        controller.HandlePoint(endPoint);
        Assert.AreEqual(true, controller.IsSolved);
    }
}
