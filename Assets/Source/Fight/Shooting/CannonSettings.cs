using UnityEngine;

namespace Source.Fight
{
    [CreateAssetMenu(fileName = "CannonSettings", menuName = "ImmortalIsland/", order = 0)]
    public class CannonSettings : ScriptableObject
    {
        [SerializeField] private float _maxDistance;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _reloadSeconds;

        public float MaxDistance => _maxDistance;
        public float Acceleration => _acceleration;
        public float ReloadSeconds => _reloadSeconds;
    }
}