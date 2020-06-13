using UnityEngine;

namespace Source.Fight.World
{
    public class WinLoseController
    {
        private readonly GameObject _finalWindow;

        public WinLoseController(GameObject finalWindow)
        {
            _finalWindow = finalWindow;
        }
        
        public bool GameWon { get; set; }
        public bool GameLost { get; set; }
        
        public void Win()
        {
            GameWon = true;
            _finalWindow.SetActive(true);
        }

        public void Lose()
        {
            GameLost = true;
            _finalWindow.SetActive(true);
        }
    }
}