using Source.Fight.Enemies;
using Source.Fight.Points;
using UnityEngine;

namespace Source.Fight.World
{
    [RequireComponent(typeof(Collider))]
    public class SkeletonKiller : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            var enemy = other.gameObject.GetComponentInParent<Enemy>();
            if (enemy != null)
            {
                Destroy(enemy.gameObject);
                PointsController.Instance.AddPoints(PointsController.Instance.Data.PointsPerSkeletonKilled);
            }
        }
    }
}