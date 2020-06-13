using Source.Fight.World;
using UnityEngine;
using Zenject;

namespace Source.Fight
{
    public class Cheat : ITickable
    {
        private readonly WinLoseController _winLoseController;
        private float _nextClickCombo;
        private int _comboClicks;

        public Cheat(WinLoseController winLoseController)
        {
            _winLoseController = winLoseController;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (Time.time < _nextClickCombo)
                {
                    _comboClicks++;
                }
                else
                {
                    _comboClicks = 1;
                }

                _nextClickCombo = Time.time + 0.3f;
                if (_comboClicks >= 5)
                {
                    _winLoseController.Win();
                }
            }
        }
    }
}