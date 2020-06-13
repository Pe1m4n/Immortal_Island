namespace Source.Fight.World
{
    public class HealthController
    {
        private readonly WorldData _worldData;
        private readonly WinLoseController _winLoseController;
        public int CurrentHealth { get; private set; }

        public HealthController(WorldData worldData, WinLoseController winLoseController)
        {
            _worldData = worldData;
            _winLoseController = winLoseController;
            CurrentHealth = _worldData.HealthCount;
        }

        public void DecrementHealth()
        {
            CurrentHealth -= 1;
            if (CurrentHealth <= 0)
            {
                _winLoseController.Lose();
            }
        }
    }
}