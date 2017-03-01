using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class BoxPuzzle : MonoBehaviour
    {
        public GameObject mechanism;

        private Animator boxAnimator;

        private void Start()
        {
            boxAnimator = GetComponent<Animator>();
        }

        private void Update()
        {
            CheckPuzzle();
        }

        private void CheckPuzzle()
        {
            if (mechanism.GetComponent<CodeCheck>().Solved)
            {
                boxAnimator.SetTrigger("Open");
            }
        }
    }
}
