using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEnabler : MonoBehaviour
{
    public Controller previousPuzzle;

    private void Update()
    {
        if (previousPuzzle == null || previousPuzzle.IsSolved)
        {
            GetComponent<Controller>().enabled = true;
            GetComponent<Draw>().enabled = true;
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
