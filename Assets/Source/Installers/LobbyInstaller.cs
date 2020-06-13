using Source.Lobby;
using UnityEngine;
using Zenject;

namespace Source.Installers
{
    public class LobbyInstaller : MonoInstaller
    {
        [SerializeField] private LocationLoaderController _locationLoader;
        [SerializeField] private LobbyRouteController _lobbyRouteController;
        
        public override void InstallBindings()
        {
            Container.Inject(_locationLoader);
            Container.Inject(_lobbyRouteController);
        }
    }
}