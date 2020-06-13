using Source.Common;
using UnityEngine;
using Zenject;

namespace Source.Installers
{
    public class LocationLoaderController : MonoBehaviour
    {
        private SceneLoader _loader;
        private NextFightController _nextFightController;
        
        [Inject]
        public void SetUp(SceneLoader loader, NextFightController nextFightController)
        {
            _loader = loader;
            _nextFightController = nextFightController;
        }

        public void LoadCurrentLocation()
        {
            if (!_nextFightController.HasCurrentLocation())
            {
                return;
            }
            
            _loader.LoadScene(_nextFightController.GetCurrentLocationName());
        }
    }
}