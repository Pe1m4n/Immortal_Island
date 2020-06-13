using System.Collections.Generic;
using Source.Installers;
using UnityEngine;
using Zenject;

namespace Source.Lobby
{
    public class LobbyRouteController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _circles;
        [SerializeField] private List<GameObject> _xMarks;
        [SerializeField] private List<GameObject> _routes;
        
        private NextFightController _nextFightController;
        [Inject]
        public void SetUp(NextFightController nextFightController)
        {
            _nextFightController = nextFightController;
        }

        private void Start()
        {
            BuildMap();
        }
        
        private void BuildMap()
        {
            var lastCompletedLevel = _nextFightController.CurrentLocation - 1;
            
            for (int i = 0; i < _xMarks.Count && i >= 0 && i <= lastCompletedLevel; i++)
            {
                _xMarks[i].SetActive(true);
            }

            if (_circles.Count > _nextFightController.CurrentLocation)
            {
                _circles[_nextFightController.CurrentLocation].SetActive(true);
            }

            if (_routes.Count  > lastCompletedLevel && lastCompletedLevel >= 0)
            {
                _routes[_nextFightController.CurrentLocation - 1].SetActive(true);
            }
        }
    }
}