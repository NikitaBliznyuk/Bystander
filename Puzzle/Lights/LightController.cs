using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Color color;

    public Material onMaterial;
    public Material offMaterial;

    public bool IsPlaced { get; private set; }

    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void TurnLight(bool on)
    {
        meshRenderer.material = on ? onMaterial : offMaterial;
        IsPlaced = on;
    }
}
