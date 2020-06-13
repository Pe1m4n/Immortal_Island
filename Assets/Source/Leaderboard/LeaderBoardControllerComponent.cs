using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Source.Leaderboard
{
    public class LeaderBoardControllerComponent : MonoBehaviour
    {
        [SerializeField] private dreamloLeaderBoard _leaderBoard;
        [SerializeField] private List<LeaderBoardRow> _rows;

        private LeaderBoardController _controller;
        private bool _init;
        
        [Inject]
        public void SetUp(LeaderBoardController controller)
        {
            _controller = controller;
        }

        private void Start()
        {
            _leaderBoard.GetScores();
        }

        private void Update()
        {
            if (_init)
            {
                return;
            }

            var scores = _leaderBoard.ToListHighToLow();
            if (scores == null || scores.Count == 0)
            {
                return;
            }

            for (int i = 0; i < scores.Count && i < _rows.Count; i++)
            {
                var score = scores[i];
                _rows[i].SetData(score.playerName, score.score.ToString());
                _rows[i].gameObject.SetActive(true);
            }

            _init = true;
        }
        
    }
}