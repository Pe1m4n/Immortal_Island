using UnityEngine;

namespace Source.Leaderboard
{
    public class LeaderBoardController
    {
        private const string HIGHEST_LOCAL_SCORE = "HLS";

        public const string PRIVATE_KEY = "vwauURVp-kusVNvKiDBh4Qc_U6SzeuPUaKHf3_upUALQ";
        public const string PUBLIC_KEY = "5ee4e49a377e860b6c4d8119";
        
        private readonly PlayerNameHolder _nameHolder;
        private readonly dreamloLeaderBoard _leaderBoard;

        public int Points { get; set; }

        public LeaderBoardController(PlayerNameHolder nameHolder, dreamloLeaderBoard leaderBoard)
        {
            _nameHolder = nameHolder;
            _leaderBoard = leaderBoard;
        }

        public void AddPoints(int points)
        {
            Points += points;
            SetScoreToLeaderBoard(Points);
        }
        
        public void SetScoreToLeaderBoard(int score)
        {
            var highestLocalScore =
                PlayerPrefs.HasKey(HIGHEST_LOCAL_SCORE) ? PlayerPrefs.GetInt(HIGHEST_LOCAL_SCORE) : 0;

            if (score < highestLocalScore)
            {
                return;
            }

            PlayerPrefs.SetInt(HIGHEST_LOCAL_SCORE, score);
            SendScoreOnline(score);
        }

        private void SendScoreOnline(int score)
        {
            _leaderBoard.AddScore(_nameHolder.Name, score);
        }
    }
}