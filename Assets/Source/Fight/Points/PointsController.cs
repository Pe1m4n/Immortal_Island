using System;
using UniRx;
using UnityEngine.UI;

namespace Source.Fight.Points
{
    public class PointsController : IDisposable
    {
        public static PointsController Instance { get; set; }

        public PointsData Data { get; private set; }
        private readonly Text _pointsLabel;
        
        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        public int Points { get; private set; }

        public PointsController(Text pointsLabel, PointsData pointsData)
        {
            _pointsLabel = pointsLabel;
            Data = pointsData;
            Instance = this;
            Observable.Interval(TimeSpan.FromSeconds(1f)).Subscribe(x =>
            {
                AddPoints(Data.PointsPerSecond);
                UpdateLabel();
            }).AddTo(_disposable);
        }

        public void AddPoints(int pointsCount)
        {
            Points += pointsCount;
        }

        public void UpdateLabel()
        {
            _pointsLabel.text = Points.ToString();
        }

        public void StopAddingPoints()
        {
            _disposable?.Dispose();
        }

        public void Dispose()
        {
            Instance = null;
            _disposable?.Dispose();
        }
    }
}