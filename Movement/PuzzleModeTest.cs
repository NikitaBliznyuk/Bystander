using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleModeTest : MonoBehaviour
{
    private MovementTest movementScript;
    private RotationTest rotationScript;

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
        }
    }
}
