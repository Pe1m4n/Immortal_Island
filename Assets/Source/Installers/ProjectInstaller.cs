using System.Collections.Generic;
using Source.Common;
using UnityEngine;
using Zenject;

namespace Source.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private LocationsInfo _locations;
        public override void InstallBindings()
        {
            Container.Bind<InputHandlingBlocker>().AsSingle();
            Container.Bind<SceneLoader>().AsSingle().NonLazy();
            Container.Bind<NextFightController>().AsSingle();
            Container.Bind<LocationsInfo>().FromInstance(_locations).AsSingle();
        }
    }
}