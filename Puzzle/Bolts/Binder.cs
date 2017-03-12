using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bolts
{
    public class Binder : MonoBehaviour
    {
        public GameObject[] items;
        public Transform mechanism;

        private int currentItemIndex = 0;

        private void Update()
        {
            BindItems();
            RotateItem();
        }

        private void BindItems()
        {
            if (Input.GetMouseButtonUp(0))
            {
                var min = Mathf.Abs(transform.position.x - items[0].transform.position.x);
                currentItemIndex = 0;
                for (int i = 1; i < items.Length; i++)
                {
                    if (Mathf.Abs(transform.position.x - items[i].transform.position.x) < min)
                    {
                        min = Mathf.Abs(transform.position.x - items[i].transform.position.x);
                        currentItemIndex = i;
                    }
                }
                var offset = transform.position.x - items[currentItemIndex].transform.position.x;
                mechanism.Translate(new Vector3(offset, 0.0f, 0.0f));
            }
        }

        private void RotateItem()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 300, LayerMask.GetMask("Level 1")))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        items[currentItemIndex].GetComponent<Rotation>().Rotate();
                    }
                }
            }
        }
    }
}
