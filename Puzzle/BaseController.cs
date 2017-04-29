using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour, ISolved {
    protected bool isSolved = false;

    public bool IsSolved()
    {
        return isSolved;
    }
}
