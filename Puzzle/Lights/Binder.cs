using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lights
{
    public class Binder : MonoBehaviour
    {
        public GameObject lamp;
        public GameObject swapLamp;

        private void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            if(Input.GetMouseButtonUp(0))
            {
                if(lamp != null)
                {
                    if (swapLamp == null)
                    {
                        lamp.transform.position = new Vector3(transform.position.x, transform.position.y, lamp.transform.position.z);
                        lamp.GetComponent<LightController>().TurnLight(true);
                    }
                    else
                    {
                        lamp.GetComponent<LightController>().TurnLight(false);
                        lamp = swapLamp;
                        lamp.transform.position = new Vector3(transform.position.x, transform.position.y, lamp.transform.position.z);
                        lamp.GetComponent<LightController>().TurnLight(true);
                        swapLamp = null;
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Lamp")
            {
                if (lamp == null)
                {
                    lamp = other.gameObject;
                }
                else
                {
                    swapLamp = other.gameObject;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            lamp = other.gameObject == lamp ? null : lamp;
            swapLamp = other.gameObject == swapLamp ? null : swapLamp;
        }
    }
}
