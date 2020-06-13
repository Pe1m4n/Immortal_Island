using Source.Common;
using UnityEngine;

namespace Source.Fight.World
{
    public class WinLoseController
    {
        private readonly GameObject _winScreen;
        private readonly GameObject _loseScreen;
        private readonly InputHandlingBlocker _inputHandlingBlocker;

        public WinLoseController(GameObject winScreen, GameObject loseScreen, InputHandlingBlocker inputHandlingBlocker)
        {
            _winScreen = winScreen;
            _loseScreen = loseScreen;
            _inputHandlingBlocker = inputHandlingBlocker;
        }
        
        public bool GameWon { get; set; }
        public bool GameLost { get; set; }
        
        public void Win()
        {
            GameWon = true;
            _winScreen.SetActive(true);
            _inputHandlingBlocker.SetAllowedInputs(InputSource.None);
        }

        public void Lose()
        {
            GameLost = true;
            _loseScreen.SetActive(true);
            _inputHandlingBlocker.SetAllowedInputs(InputSource.None);
        }
    }
}