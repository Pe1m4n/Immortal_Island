using System.Collections.Generic;
using UnityEngine;

namespace Source.Fight.World
{
    [CreateAssetMenu(fileName = "NewWorldData", menuName = "Immortal_Island/World Data", order = 0)]
    public class WorldData : ScriptableObject
    {
        [SerializeField] private int _healthCount;
        [SerializeField] private float _roundTime;
        [SerializeField] private List<SpawnData> _spawns;

        public int HealthCount => _healthCount;
        public float RoundTime => _roundTime;
        public List<SpawnData> Spawns => _spawns;
    }
}