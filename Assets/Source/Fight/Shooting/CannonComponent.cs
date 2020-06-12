using Source.Common;
using UnityEngine;
using Zenject;

namespace Source.Fight
{
    public class CannonComponent : MonoBehaviour
    {
        [SerializeField] private CannonSettings _cannonSettings;
        [SerializeField] private ExplosionObject _explosionObject;

        private RotationComponent _rotationComponent;
        private ShootingComponent _shootingComponent;

        [Inject]
        public void SetUp(Camera mainCamera, InputHandlingBlocker inputHandlingBlocker, IInstantiator instantiator)
        {
            _rotationComponent = new RotationComponent(mainCamera, transform);
            _shootingComponent = new ShootingComponent(_cannonSettings, inputHandlingBlocker,
                transform, _explosionObject, instantiator);
        }

        private void Update()
        {
            if (_rotationComponent == null || _shootingComponent == null)
            {
                return;
            }
            
            _rotationComponent.Update();
            _shootingComponent.Update();
        }
    }
}