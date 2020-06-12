using UnityEngine;
using UnityEngine.UI;

namespace Source.Fight
{
    public class ShotPowerChargingComponent
    {
        private readonly CannonSettings _settings;
        private AimTextureController _aimController;

        private float _currentPower;
        public bool IsCharging { get; private set; }

        public ShotPowerChargingComponent(CannonSettings settings, Image aimBarImage)
        {
            _settings = settings;
            _aimController = new AimTextureController(aimBarImage);
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

            _currentPower += Time.deltaTime * (1f / _settings.Acceleration);
            _aimController.SetAimPower(_currentPower);
        }

        public float StopChargingAndGetValue()
        {
            var temp = Mathf.Clamp01(_currentPower);
            IsCharging = false;
            _currentPower = 0f;
            _aimController.SetAimPower(_currentPower);
            return temp;
        }
    }
}