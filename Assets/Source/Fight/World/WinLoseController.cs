using Source.Common;
using UnityEngine;

namespace Source.Fight.World
{
    public class WinLoseController
    {
        private readonly GameObject _winScreen;
        private readonly GameObject _loseScreen;
        private readonly InputHandlingBlocker _inputHandlingBlocker;
        private readonly AudioSource _sceneMusicSource;

        public WinLoseController(GameObject winScreen, GameObject loseScreen,
            InputHandlingBlocker inputHandlingBlocker, AudioSource sceneMusicSource)
        {
            _winScreen = winScreen;
            _loseScreen = loseScreen;
            _inputHandlingBlocker = inputHandlingBlocker;
            _sceneMusicSource = sceneMusicSource;
        }
        
        public bool GameWon { get; set; }
        public bool GameLost { get; set; }
        
        public void Win()
        {
            GameWon = true;
            _winScreen.SetActive(true);
            _inputHandlingBlocker.SetAllowedInputs(InputSource.None);
            _sceneMusicSource.Stop();
        }

        public void Lose()
        {
            GameLost = true;
            _loseScreen.SetActive(true);
            _inputHandlingBlocker.SetAllowedInputs(InputSource.None);
            _sceneMusicSource.Stop();
        }
    }
}