using UnityEngine;
using Zenject;

namespace Source.Fight.World
{
    public class RoundTimeController : ITickable
    {
        private readonly WinLoseController _winLoseController;
        public float CurrentTime { get; private set; }
        
        public RoundTimeController(WorldData data, WinLoseController winLoseController)
        {
            _winLoseController = winLoseController;
            CurrentTime = data.RoundTime;
        }

        public void Tick()
        {
            CurrentTime -= Time.deltaTime;
            if (CurrentTime <= 0 && !_winLoseController.GameLost)
            {
                _winLoseController.Win();
            }
        }
    }
}