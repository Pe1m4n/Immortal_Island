using System;
using Source.Leaderboard;
using UniRx;
using UnityEngine.UI;

namespace Source.Fight.Points
{
    public class PointsController : IDisposable
    {
        public static PointsController Instance { get; set; }

        public PointsData Data { get; private set; }
        private readonly Text _pointsLabel;
        private readonly LeaderBoardController _leaderBoardController;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        public int Points { get; private set; }

        public PointsController(Text pointsLabel, PointsData pointsData, LeaderBoardController leaderBoardController)
        {
            _pointsLabel = pointsLabel;
            _leaderBoardController = leaderBoardController;
            Points = _leaderBoardController.Points;
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

        public void FinalizePoints()
        {
            _leaderBoardController.AddPoints(Points);
        }
        
        public void ResetPoints()
        {
            Points = _leaderBoardController.Points;
        }

        public void Dispose()
        {
            Instance = null;
            _disposable?.Dispose();
        }
    }
}