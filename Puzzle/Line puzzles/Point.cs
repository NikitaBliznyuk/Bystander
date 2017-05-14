using UnityEngine;

namespace Puzzle.Line_puzzles
{
    public class Point : MonoBehaviour
    {
        public GameObject[] Neighbours;
        public Material HowerMaterial;
        public Material LightMaterial;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                _backlight.GetComponent<MeshRenderer>().material = _isBusy ? LightMaterial : HowerMaterial;
            }
        }

        private bool _isBusy;
        private GameObject _backlight;

        private void Awake()
        {
            _backlight = transform.GetChild(0).gameObject;
            IsBusy = false;
        }

        public void TurnBacklight(bool on)
        {
            _backlight.SetActive(on);
        }

        private void Update()
        {
            TurnBacklight(CheckHower() || _isBusy);
        }

        private bool CheckHower()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 300))
            {
                if (hit.collider.gameObject == gameObject)
                    return true;
            }

            return false;
        }

        public bool IsNeighbour(GameObject point)
        {
            if (_isBusy)
                return false;

            foreach (var neighbour in Neighbours)
            {
                if (neighbour == point)
                {
                    IsBusy = true;
                    return true;
                }
            }
            return false;
        }
    }
}
