using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Source.Fight.World
{
    public class RoundTimeController : ITickable, IDisposable
    {
        private readonly WinLoseController _winLoseController;
        private readonly Text _timerText;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        public float CurrentTime { get; private set; }
        
        public RoundTimeController(WorldData data, WinLoseController winLoseController, Text timerText)
        {
            _winLoseController = winLoseController;
            _timerText = timerText;
            CurrentTime = data.RoundTime;
            UpdateTime();
            
            Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(
                x =>
                {
                    UpdateTime();
                }).AddTo(_disposable);
        }

        public void Tick()
        {
            CurrentTime -= Time.deltaTime;
            if (CurrentTime <= 0 && !_winLoseController.GameLost)
            {
                _winLoseController.Win();
                Dispose();
            }
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }

        private void UpdateTime()
        {
            if (_winLoseController.GameLost || _winLoseController.GameWon)
            {
                return;
            }
            TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
            _timerText.text = time.ToString(@"mm\:ss");
        }
    }
}