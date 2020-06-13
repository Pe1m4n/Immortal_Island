namespace Source.Fight.World
{
    public class WinLoseController
    {
        public bool GameWon { get; set; }
        public bool GameLost { get; set; }
        
        public void Win()
        {
            GameWon = true;
        }

        public void Lose()
        {
            GameLost = true;
        }
    }
}