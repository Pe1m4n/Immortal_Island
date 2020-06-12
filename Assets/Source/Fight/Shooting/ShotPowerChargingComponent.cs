using UnityEngine;

namespace Source.Fight
{
    public class ShotPowerChargingComponent
    {
        private readonly CannonSettings _settings;

        private float _currentPower;
        public bool IsCharging { get; private set; }

        public ShotPowerChargingComponent(CannonSettings settings)
        {
            _settings = settings;
        }
        
        public void StartCharging()
        {
            IsCharging = true;
        }

        public void Update()
        {
            if (!IsCharging)
            {
                return;
            }

            _currentPower += Time.deltaTime * _settings.Acceleration;
        }

        public float StopChargingAndGetValue()
        {
            var temp = Mathf.Clamp01(_currentPower);
            IsCharging = false;
            _currentPower = 0f;
            return temp;
        }
    }
}