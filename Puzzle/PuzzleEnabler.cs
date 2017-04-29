using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEnabler : MonoBehaviour
{
    public BaseController PreviousPuzzle;
    public GameObject puzzle;

    private ISolved previousPuzzle;

    private void Start()
    {
        previousPuzzle = PreviousPuzzle;
    }

    private void Update()
    {
        if (PreviousPuzzle == null || previousPuzzle.IsSolved())
        {
            puzzle.SetActive(true);
        }
    }
}
