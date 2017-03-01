using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code {
    public class CodeCheck : MonoBehaviour
    {
        private readonly string code = "1234567";

        private void Update()
        {
            if(code == GetCode())
            {
                Debug.Log("Correct");
            }
        }

        private string GetCode()
        {
            var objects = gameObject.GetComponentsInChildren<Rotation>();
            
            string result = "";

            foreach (var child in objects)
            {
                result += child.Number;
            }

            return result;
        }
    }
}