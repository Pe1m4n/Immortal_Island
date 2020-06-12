using UnityEngine;

namespace Source.Fight
{
    [CreateAssetMenu(fileName = "ExplosionData", menuName = "Immortal_Island/Explosion Data", order = 0)]
    public class ExplosionData : ScriptableObject
    {
        [SerializeField] private float _explosionStunRadius;
        [SerializeField] private float _explosionMoveRadius;

        [SerializeField] private float _throwPowerMax;
        [SerializeField] private float _throwPowerMin;
        [SerializeField] private float _movePower;
        
        [SerializeField] private float _stunDuration;
        [SerializeField] private float _upwardsForce;

        public float ExplosionStunRadius => _explosionStunRadius;
        public float ExplosionMoveRadius => _explosionMoveRadius;
        public float ThrowPowerMax => _throwPowerMax;
        public float ThrowPowerMin => _throwPowerMin;
        public float MovePower => _movePower;

        public float StunDuration => _stunDuration;
        public float UpwardsForce => _upwardsForce;
    }
}