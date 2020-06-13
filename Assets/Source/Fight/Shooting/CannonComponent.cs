using Source.Common;
using Source.Fight.Sounds;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Source.Fight
{
    public class CannonComponent : MonoBehaviour
    {
        [SerializeField] private CannonSettings _cannonSettings;
        [SerializeField] private ExplosionObject _explosionObject;
        [SerializeField] private Image _aimImage;
        [SerializeField] private AudioSource _wickAudio;
        [SerializeField] private RandomSoundsPlayer _shotsSoundPlayer;
        [SerializeField] private UnityEvent _onShot;

        private RotationComponent _rotationComponent;
        private ShootingComponent _shootingComponent;

        [Inject]
        public void SetUp(Camera mainCamera, InputHandlingBlocker inputHandlingBlocker, IInstantiator instantiator)
        {
            _rotationComponent = new RotationComponent(mainCamera, transform);
            _shootingComponent = new ShootingComponent(_cannonSettings, inputHandlingBlocker,
                transform, _explosionObject, instantiator, _aimImage, _wickAudio, _shotsSoundPlayer, _onShot);
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