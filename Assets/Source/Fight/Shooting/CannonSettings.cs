using UnityEngine;

namespace Source.Fight
{
    [CreateAssetMenu(fileName = "CannonSettings", menuName = "Immortal_Island/CannonSetting", order = 0)]
    public class CannonSettings : ScriptableObject
    {
        [SerializeField] private float _maxDistance;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _reloadSeconds;
        [SerializeField] private float _explosionDelayMin;
        [SerializeField] private float _explosionDelayMax;

        public float MaxDistance => _maxDistance;
        public float Acceleration => _acceleration;
        public float ReloadSeconds => _reloadSeconds;
        public float ExplosionDelayMin => _explosionDelayMin;
        public float ExplosionDelayMax => _explosionDelayMax;
    }
}