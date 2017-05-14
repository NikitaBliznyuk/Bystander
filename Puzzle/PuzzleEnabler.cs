using UnityEngine;

namespace Puzzle
{
    public class PuzzleEnabler : MonoBehaviour
    {
        public BaseController PreviousPuzzle;
        public GameObject Puzzle;

        private ISolved _previousPuzzle;

        private void Start()
        {
            _previousPuzzle = PreviousPuzzle;
        }

        private void Update()
        {
            if (PreviousPuzzle == null || _previousPuzzle.IsSolved())
            {
                Puzzle.SetActive(true);
            }
        }
    }
}
