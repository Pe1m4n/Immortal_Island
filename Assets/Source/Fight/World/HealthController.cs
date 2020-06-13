using UnityEngine.UI;

namespace Source.Fight.World
{
    public class HealthController
    {
        private readonly WorldData _worldData;
        private readonly WinLoseController _winLoseController;
        private readonly Text _healthText;
        public int CurrentHealth { get; private set; }

        public HealthController(WorldData worldData, WinLoseController winLoseController, Text healthText)
        {
            _worldData = worldData;
            _winLoseController = winLoseController;
            _healthText = healthText;
            CurrentHealth = _worldData.HealthCount;
            UpdateHealth();
        }

        public void DecrementHealth()
        {
            CurrentHealth -= 1;
            if (CurrentHealth <= 0)
            {
                _winLoseController.Lose();
            }
            UpdateHealth();
        }

        private void UpdateHealth()
        {
            _healthText.text = $"{CurrentHealth}/{_worldData.HealthCount}";
        }
    }
}