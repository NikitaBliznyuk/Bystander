using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEnabler : MonoBehaviour
{
    public Controller PreviousPuzzle;
    public GameObject puzzle;

    private void Update()
    {
        if (PreviousPuzzle == null || ((ISolved)PreviousPuzzle).IsSolved())
        {
            puzzle.SetActive(true);
        }
    }
}
