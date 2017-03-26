using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code {
    public class CodeCheck : MonoBehaviour
    {
        public bool Solved { get; private set; }

        public readonly Numbers[] code =
        {
            Numbers.Zero,
            Numbers.Eight,
            Numbers.Seven,
            Numbers.Two,
            Numbers.Three,
            Numbers.Six,
            Numbers.Nine
        };

        private void Start()
        {
            Solved = false;
        }

        private void Update()
        {
            if(!Solved)
                CheckEnteredCode(GetCode());
        }

        private Numbers[] GetCode()
        {
            var children = gameObject.GetComponentsInChildren<Rotation>();
            
            Numbers[] result = new Numbers[children.Length];

            for (int i = 0; i < children.Length; i++)
            {
                result[i] = children[i].Number;
            }

            return result;
        }

        private void CheckEnteredCode(Numbers[] enteredCode)
        {
            for (int i = 0; i < enteredCode.Length; i++)
            {
                if (code[i] != enteredCode[i])
                {
                    return;
                }
            }

            Debug.Log("Right!");

            Solved = true;
        }
    }
}