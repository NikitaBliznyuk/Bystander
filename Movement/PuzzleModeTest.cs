using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleModeTest : MonoBehaviour
{
    private MovementTest movementScript;
    private RotationTest rotationScript;

    private bool puzzleMode = false;

    private Transform nearPuzzle;

    private void Start()
    {
        movementScript = GetComponent<MovementTest>();
        rotationScript = GetComponent<RotationTest>();
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            movementScript.enabled = !movementScript.enabled;
            rotationScript.enabled = !rotationScript.enabled;
            puzzleMode = !puzzleMode;
            if (puzzleMode)
                MoveCamera();
        }
    }

    private void MoveCamera()
    {
        if(nearPuzzle != null)
        {
            transform.position = new Vector3(nearPuzzle.position.x, transform.position.y, nearPuzzle.position.z);
            Camera.main.transform.LookAt(nearPuzzle.GetComponentsInParent<Transform>()[1]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Puzzle")
        {
            nearPuzzle = other.gameObject.GetComponentsInChildren<Transform>()[1];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Puzzle")
        {
            nearPuzzle = null;
        }
    }
}
