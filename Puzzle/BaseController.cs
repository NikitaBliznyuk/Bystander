using UnityEngine;

namespace Puzzle
{
    public abstract class BaseController : MonoBehaviour, ISolved {
        public string Name;

        protected bool PuzzleSolved;

        protected virtual void Load()
        {
            if (PlayerPrefs.HasKey(Name))
                PuzzleSolved = PlayerPrefs.GetInt(Name) != 0;
            else
                PuzzleSolved = false;
        }

        protected abstract void Update();

        public bool IsSolved()
        {
            return PuzzleSolved;
        }
    }
}
