using Source.Common;
using Source.Fight.Points;
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
        private readonly PointsController _pointsController;

        public WinLoseController(GameObject winScreen, GameObject loseScreen,
            InputHandlingBlocker inputHandlingBlocker, AudioSource sceneMusicSource,
            NextFightController nextFightController, PointsController pointsController)
        {
            _winScreen = winScreen;
            _loseScreen = loseScreen;
            _inputHandlingBlocker = inputHandlingBlocker;
            _sceneMusicSource = sceneMusicSource;
            _nextFightController = nextFightController;
            _pointsController = pointsController;
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
            _pointsController.StopAddingPoints();
            _pointsController.AddPoints(_pointsController.Data.PointsForWin);
            _pointsController.FinalizePoints();
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
            _pointsController.StopAddingPoints();
        }
    }
}