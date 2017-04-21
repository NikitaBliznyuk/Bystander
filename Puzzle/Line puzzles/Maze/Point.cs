using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public GameObject[] neighbours;
    public Material howerMaterial;
    public Material lightMaterial;

    public bool IsBusy
    {
        get
        {
            return isBusy;
        }
        set
        {
            isBusy = value;
            backlight.GetComponent<MeshRenderer>().material = isBusy ? lightMaterial : howerMaterial;
        }
    }

    private bool isBusy = false;
    private GameObject backlight;

    private void Start()
    {
        backlight = transform.GetChild(0).gameObject;
        IsBusy = false;
    }

    private void Update()
    {
        backlight.SetActive(CheckHower() || isBusy);
    }

    private bool CheckHower()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 300))
        {
            if (hit.collider.gameObject == gameObject)
                return true;
        }

        return false;
    }

    public bool IsNeighbour(GameObject point)
    {
        if (isBusy)
            return false;

        foreach (var neighbour in neighbours)
        {
            if (neighbour == point)
            {
                IsBusy = true;
                return true;
            }
        }
        return false;
    }
}
