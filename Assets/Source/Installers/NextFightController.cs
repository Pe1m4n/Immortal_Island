using Source.Common;

namespace Source.Installers
{
    public class NextFightController
    {
        private readonly LocationsInfo _locationsInfo;
        public int CurrentLocation { get; private set; }

        public NextFightController(LocationsInfo locationsInfo)
        {
            _locationsInfo = locationsInfo;
        }

        public void CompleteLocation()
        {
            CurrentLocation++;
        }

        public bool HasCurrentLocation()
        {
            return CurrentLocation < _locationsInfo.LocationNames.Count;
        }
        
        public string GetCurrentLocationName()
        {
            return _locationsInfo.LocationNames[CurrentLocation];
        }
    }
}