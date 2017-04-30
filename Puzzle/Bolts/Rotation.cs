using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bolts
{
    public class Rotation : MonoBehaviour
    {
        public bool rotated = false;
        public GameObject neighboor;

        public void Rotate()
        {
            if (neighboor == null || !neighboor.GetComponent<Rotation>().rotated)
            {
                transform.Rotate(0.0f, 0.0f, rotated ? 90.0f : -90.0f);
                rotated = !rotated;
            }
        }
    }
}
