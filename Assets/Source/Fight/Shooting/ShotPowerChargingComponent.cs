using UnityEngine;

namespace Source.Fight
{
    public class ShotPowerChargingComponent
    {
        private readonly CannonSettings _settings;

        private float _currentPower;
        private bool _isCharging;

        public ShotPowerChargingComponent(CannonSettings settings)
        {
            _settings = settings;
        }
        
        public void StartCharging()
        {
            _isCharging = true;
        }

        public void Update()
        {
            if (!_isCharging)
            {
                return;
            }

            _currentPower += Mathf.Clamp01(Time.deltaTime * _settings.Acceleration);
        }

        public float StopChargingAndGetValue()
        {
            var temp = _currentPower;
            _isCharging = false;
            _currentPower = 0f;
            return _currentPower;
        }
    }
}