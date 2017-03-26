using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lights
{
    public class PuzzleAnalizer : MonoBehaviour
    {
        public GameObject[] brokenLines;
        public GameObject[] verticalLines;
        public GameObject[] horizontalLines;

        private void Update()
        {
            CheckWin();
        }

        private bool CheckWin()
        {
            if (!CheckLine(brokenLines) || !CheckLine(verticalLines) || !CheckLine(horizontalLines))
                return false;

            return true;
        }

        private bool CheckLine(GameObject[] lineArray)
        {
            for (int i = 0; i < lineArray.Length; i += 6)
            {
                var line = new GameObject[6];

                for (int k = 0; k < 6; k++)
                {
                    line[k] = lineArray[i + k];
                }

                if (!CheckColors(line))
                    return false;
            }

            return true;
        }

        private bool CheckColors(GameObject[] array)
        {
            var colorsArray = new int[6];

            for (int i = 0; i < array.Length; i++)
            {
                var binder = array[i].GetComponent<Binder>();

                if (binder.lamp == null)
                    return false;

                var index = (int)binder.lamp.GetComponent<LightController>().color;
                colorsArray[index]++;
            }

            foreach(var color in colorsArray)
            {
                if (color != 1)
                    return false;
            }

            return true;
        }
    }
}
