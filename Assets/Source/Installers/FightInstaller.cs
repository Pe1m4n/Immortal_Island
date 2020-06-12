using Source.Fight;
using UnityEngine;
using Zenject;

namespace Source.Installers
{
    public class FightInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private CannonComponent _cannon;

        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromInstance(_camera).AsSingle();
            
            
            Container.Inject(_cannon);
        }
    }
}