using Source.Common;
using UnityEngine;
using Zenject;

namespace Source.Fight
{
    public class ShootingComponent
    {
        private readonly CannonSettings _settings;
        private readonly InputHandlingBlocker _inputHandlingBlocker;
        private readonly Transform _cannonTransform;
        private readonly ReloadComponent _reloadComponent;
        private readonly ShotPowerChargingComponent _powerChargingComponent;
        private readonly ExplosionComponent _explosionComponent;

        public ShootingComponent(CannonSettings settings, InputHandlingBlocker inputHandlingBlocker,
            Transform cannonTransform, ExplosionObject explosionObject, IInstantiator instantiator)
        {
            _settings = settings;
            _inputHandlingBlocker = inputHandlingBlocker;
            _cannonTransform = cannonTransform;
            _reloadComponent = new ReloadComponent(_settings);
            _powerChargingComponent = new ShotPowerChargingComponent(_settings);
            _explosionComponent = new ExplosionComponent(explosionObject, instantiator);
        }

        public void Update()
        {
            _powerChargingComponent.Update();
            
            if (!_inputHandlingBlocker.IsInputSourceAllowed(InputSource.Cannon) || !_reloadComponent.CanShoot)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _powerChargingComponent.StartCharging();
            }

            if (Input.GetKeyUp(KeyCode.Mouse0) && _powerChargingComponent.IsCharging)
            {
                var power = _powerChargingComponent.StopChargingAndGetValue();
                _reloadComponent.OnShot();

                Debug.LogError($"Firing with power {power}");
                
                var shotPosition = GetShotPositionForPower(power);
                _explosionComponent.SpawnExplosionAt(shotPosition);
            }
        }

        private Vector3 GetShotPositionForPower(float power)
        {
            return _cannonTransform.position + (_cannonTransform.forward.normalized * _settings.MaxDistance * power);
        }
    }
}