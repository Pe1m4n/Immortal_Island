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

        public void Start()
        {
            Observable.Timer(TimeSpan.FromSeconds(2)).Subscribe(l =>
            {
                DestroyMe();
            });

            var stunColliders = Physics.OverlapSphere(transform.position, _explosionData.ExplosionStunRadius);
            var moveColliders = Physics.OverlapSphere(transform.position, _explosionData.ExplosionMoveRadius)
                .Where(x => !stunColliders.Contains(x));

            var moveTargets = GetEnemies(moveColliders);
            
            Stun(GetEnemies(stunColliders));
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

        private void Stun(IEnumerable<Enemy> enemies)
        {
            foreach (var enemy in enemies)
            {
                enemy.StunComponent.StunForSeconds(_explosionData.StunDuration);
            }
        }
        
        public void DestroyMe()
        {
            Destroy(gameObject);
        }
    }
}