using System;
using System.Collections.Generic;
using System.Linq;
using Source.Fight.Enemies;
using UniRx;
using UnityEngine;

namespace Source.Fight
{
    public class ExplosionObject : MonoBehaviour
    {
        [SerializeField] private ExplosionData _explosionData;
        [SerializeField] private GameObject _debugSphereHit;
        [SerializeField] private GameObject _debugSphereEnemy;

        public void Start()
        {
            Observable.Timer(TimeSpan.FromSeconds(2)).Subscribe(l =>
            {
                DestroyMe();
            });

            var stunColliders = Physics.OverlapSphere(transform.position, _explosionData.ExplosionStunRadius);

            if (_debugSphereHit != null)
            {
                Instantiate(_debugSphereHit, transform.position, transform.rotation, null);
            }
            
            Stun(GetEnemies(stunColliders), transform.position);
        }

        private IEnumerable<Enemy> GetEnemies(IEnumerable<Collider> colliders)
        {
            var enemies = new List<Enemy>();
            foreach (var collider in colliders)
            {
                var enemy = collider.GetComponentInParent<Enemy>();
                if (enemy == null)
                {
                    continue;
                }
                enemies.Add(enemy);
            }

            return enemies;
        }

        private void Move(IEnumerable<Enemy> enemies)
        {
            foreach (var enemy in enemies)
            {
                Debug.LogError($"Enemy moved");
            }
        }

        private void Stun(IEnumerable<Enemy> enemies, Vector3 position)
        {
            foreach (var enemy in enemies)
            {
                enemy.StunComponent.StunForSeconds(_explosionData.StunDuration, new ExplosionArgs(
                    position,
                    _explosionData.ThrowPower,
                    _explosionData.ExplosionStunRadius,
                    _explosionData.UpwardsForce));
                
                if (_debugSphereEnemy != null)
                {
                    Instantiate(_debugSphereEnemy, enemy.transform.position, enemy.transform.rotation, null);
                }
            }
        }
        
        public void DestroyMe()
        {
            Destroy(gameObject);
        }
    }
}