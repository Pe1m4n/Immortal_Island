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
        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        public float CurrentTime { get; private set; }
        
        public RoundTimeController(WorldData data, WinLoseController winLoseController, Text timerText)
        {
            _winLoseController = winLoseController;
            CurrentTime = data.RoundTime;
            Observable.Interval(TimeSpan.FromMilliseconds(1000)).Subscribe(
                x => 
            {
                TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
                timerText.text = time.ToString(@"mm\:ss");
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
    }
}