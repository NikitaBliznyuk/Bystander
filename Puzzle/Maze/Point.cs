using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public GameObject[] neighbours;

    public bool IsNeighbour(GameObject point)
    {
        foreach (var neighbour in neighbours)
        {
            if (neighbour == point)
                return true;
        }
        return false;
    }
}
