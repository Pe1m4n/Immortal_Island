using Source.Common;
using Source.Installers;
using UnityEngine;

namespace Source.Fight.World
{
    public class WinLoseController
    {
        private readonly GameObject _winScreen;
        private readonly GameObject _loseScreen;
        private readonly InputHandlingBlocker _inputHandlingBlocker;
        private readonly AudioSource _sceneMusicSource;
        private readonly NextFightController _nextFightController;

        public WinLoseController(GameObject winScreen, GameObject loseScreen,
            InputHandlingBlocker inputHandlingBlocker, AudioSource sceneMusicSource, NextFightController nextFightController)
        {
            _winScreen = winScreen;
            _loseScreen = loseScreen;
            _inputHandlingBlocker = inputHandlingBlocker;
            _sceneMusicSource = sceneMusicSource;
            _nextFightController = nextFightController;
        }
        
        public bool GameWon { get; set; }
        public bool GameLost { get; set; }
        
        public void Win()
        {
            if (GameWon)
            {
                return;
            }
            
            GameWon = true;
            _winScreen.SetActive(true);
            _inputHandlingBlocker.SetAllowedInputs(InputSource.None);
            _sceneMusicSource.Stop();
            _nextFightController.CompleteLocation();
        }

        public void Lose()
        {
            if (GameLost)
            {
                return;
            }
            
            GameLost = true;
            _loseScreen.SetActive(true);
            _inputHandlingBlocker.SetAllowedInputs(InputSource.None);
            _sceneMusicSource.Stop();
        }
    }
}