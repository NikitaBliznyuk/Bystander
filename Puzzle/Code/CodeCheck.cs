using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code {
    public class CodeCheck : MonoBehaviour
    {
        public bool Solved { get; private set; }

        private readonly Numbers[] code =
        {
            Numbers.One,
            Numbers.Two,
            Numbers.Three,
            Numbers.Four,
            Numbers.Five,
            Numbers.Six,
            Numbers.Seven
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