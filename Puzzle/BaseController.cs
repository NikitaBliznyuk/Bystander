using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour, ISolved {
    public string Name;

    protected bool isSolved = false;

    protected virtual void Load()
    {
        if (PlayerPrefs.HasKey(Name))
            isSolved = PlayerPrefs.GetInt(Name) == 0 ? false : true;
        else
            isSolved = false;
    }

    protected abstract void Update();

    public bool IsSolved()
    {
        return isSolved;
    }
}
