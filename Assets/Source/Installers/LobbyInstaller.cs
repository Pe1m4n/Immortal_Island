using Source.Leaderboard;
using Source.Lobby;
using UnityEngine;
using Zenject;

namespace Source.Installers
{
    public class LobbyInstaller : MonoInstaller
    {
        [Header("Just injectables")]
        [SerializeField] private LocationLoaderController _locationLoader;
        [SerializeField] private LobbyRouteController _lobbyRouteController;
        [SerializeField] private PlayerNameSetter _nameSetter;
        
        
        [SerializeField] private GameObject _enterNameWindow;
        [SerializeField] private GameObject _newUserWindow;
        [SerializeField] private GameObject _mapWindow;
        
        public override void InstallBindings()
        {
            Container.Inject(_locationLoader);
            Container.Inject(_lobbyRouteController);
            Container.Inject(_nameSetter);

            Container.BindInterfacesTo<LobbyController>().AsSingle()
                .WithArguments(_enterNameWindow, _newUserWindow, _mapWindow);
        }
    }
}