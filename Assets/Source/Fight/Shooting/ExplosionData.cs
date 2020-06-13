using UnityEngine;
using UnityEngine.Serialization;

namespace Source.Fight
{
    [CreateAssetMenu(fileName = "ExplosionData", menuName = "Immortal_Island/Explosion Data", order = 0)]
    public class ExplosionData : ScriptableObject
    {
        [SerializeField] private float _explosionStunRadius;

        [FormerlySerializedAs("_throwPowerMax")] [SerializeField] private float _throwPower;
        
        [SerializeField] private float _stunDuration;
        [SerializeField] private float _upwardsForce;

        public float ExplosionStunRadius => _explosionStunRadius;
        public float ThrowPower => _throwPower;
        public float StunDuration => _stunDuration;
        public float UpwardsForce => _upwardsForce;
    }
}