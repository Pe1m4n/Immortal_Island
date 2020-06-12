using UnityEngine;

namespace Source.Fight.Enemies
{
    public struct ExplosionArgs
    {
        public Vector3 ExplosionPosition { get; }
        public float Force { get; }
        public float Radius { get; }
        public float Upwards { get; }

        public ExplosionArgs(Vector3 explosionPosition, float force, float radius, float upwards)
        {
            ExplosionPosition = explosionPosition;
            Force = force;
            Radius = radius;
            Upwards = upwards;
        }
    }
}