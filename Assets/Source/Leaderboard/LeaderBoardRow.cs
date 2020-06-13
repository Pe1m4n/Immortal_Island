using UnityEngine;
using UnityEngine.UI;

namespace Source.Leaderboard
{
    public class LeaderBoardRow : MonoBehaviour
    {
        [SerializeField] private Text _nameText;
        [SerializeField] private Text _valueText;

        public void SetData(string name, string score)
        {
            _nameText.text = name;
            _valueText.text = score;
        }
    }
}