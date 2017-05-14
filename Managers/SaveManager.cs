using System.Collections;
using System.Collections.Generic;
using Puzzle;
using UnityEngine;

public class SaveManager : MonoBehaviour {
    public BaseController[] puzzles;
    public Transform player;

    private float saveDelay = 1.0f;
    private float currentTime = 0.0f;

    private void Update()
    {
        if (currentTime < saveDelay)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            currentTime = 0.0f;

            foreach(var puzzle in puzzles)
            {
                PlayerPrefs.SetInt(puzzle.Name, ((ISolved)puzzle).IsSolved() == true ? 1 : 0);
            }

            PlayerPrefs.SetFloat("Player X", player.position.x);
            PlayerPrefs.SetFloat("Player Y", player.position.y);
            PlayerPrefs.SetFloat("Player Z", player.position.z);
        }
    }
}
