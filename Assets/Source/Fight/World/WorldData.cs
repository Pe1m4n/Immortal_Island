using UnityEngine;

namespace Source.Fight.World
{
    public class WorldData : ScriptableObject
    {
        [SerializeField] private int _healthCount;
        [SerializeField] private float _roundTime;

        public int HealthCount => _healthCount;
        public float RoundTime => _roundTime;
    }
}