using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Source.Installers
{
    public class LobbyInstaller : MonoInstaller
    {
        [SerializeField] private LocationLoaderController _locationLoader;
        public override void InstallBindings()
        {
            Container.Inject(_locationLoader);
        }
    }
}