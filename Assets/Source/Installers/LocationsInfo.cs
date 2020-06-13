using System.Collections.Generic;
using UnityEngine;

namespace Source.Installers
{
    [CreateAssetMenu(fileName = "LocationsInfo", menuName = "Immortal_Island/Locations info", order = 0)]
    public class LocationsInfo : ScriptableObject
    {
        [SerializeField] private List<string> _locationNames;

        public List<string> LocationNames => _locationNames;
    }
}