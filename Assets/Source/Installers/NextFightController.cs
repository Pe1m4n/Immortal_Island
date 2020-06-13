using Source.Common;

namespace Source.Installers
{
    public class NextFightController
    {
        private readonly LocationsInfo _locationsInfo;
        private int _currentLocation;

        public NextFightController(LocationsInfo locationsInfo)
        {
            _locationsInfo = locationsInfo;
        }

        public void CompleteLocation()
        {
            _currentLocation++;
        }

        public bool HasCurrentLocation()
        {
            return _currentLocation < _locationsInfo.LocationNames.Count;
        }
        
        public string GetCurrentLocationName()
        {
            return _locationsInfo.LocationNames[_currentLocation];
        }
    }
}