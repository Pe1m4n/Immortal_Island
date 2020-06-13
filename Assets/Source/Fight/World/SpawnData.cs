using System;
using Source.Fight.Enemies;

namespace Source.Fight.World
{
    [Serializable]
    public class SpawnData
    {
        public float secondsTillSpawn;
        public EnemyData enemy;
        public int count;
    }
}