using UnityEngine;

namespace Source.Leaderboard
{
    public class LeaderBoardController
    {
        private const string HIGHEST_LOCAL_SCORE = "HLS";

        public const string PRIVATE_KEY = "vwauURVp-kusVNvKiDBh4Qc_U6SzeuPUaKHf3_upUALQ";
        public const string PUBLIC_KEY = "5ee4e49a377e860b6c4d8119";
        
        private readonly PlayerNameHolder _nameHolder;

        public LeaderBoardController(PlayerNameHolder nameHolder)
        {
            _nameHolder = nameHolder;
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
        }
    }
}