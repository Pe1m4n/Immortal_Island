using UnityEngine;

namespace Source.Fight.Enemies
{
    [CreateAssetMenu(fileName = "NewEnemyData", menuName = "Immortal_Island/Enemy Data", order = 0)]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Enemy _prefab;

        public Enemy Prefab => _prefab;
        public string Name => _name;
    }
}