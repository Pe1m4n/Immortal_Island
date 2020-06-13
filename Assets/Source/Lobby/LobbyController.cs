using Source.Installers;
using Source.Leaderboard;
using UnityEngine;
using Zenject;

namespace Source.Lobby
{
    public class LobbyController : IInitializable
    {
        private readonly GameObject _enterNameWindow;
        private readonly GameObject _newUserWindow;
        private readonly GameObject _mapWindow;
        private readonly PlayerNameHolder _playerNameHolder;
        private readonly NextFightController _nextFightController;

        public LobbyController(GameObject enterNameWindow, PlayerNameHolder playerNameHolder,
            GameObject newUserWindow, GameObject mapWindow, 
            NextFightController nextFightController)
        {
            _enterNameWindow = enterNameWindow;
            _playerNameHolder = playerNameHolder;
            _newUserWindow = newUserWindow;
            _mapWindow = mapWindow;
            _nextFightController = nextFightController;
        }

        public void Initialize()
        {
            if (_playerNameHolder.ShouldEnterName())
            {
                _enterNameWindow.SetActive(true);
                return;
            }

            if (_nextFightController.CurrentLocation > 0)
            {
                _mapWindow.SetActive(true);
                return;
            }
            
            _newUserWindow.SetActive(true);
        }
    }
}