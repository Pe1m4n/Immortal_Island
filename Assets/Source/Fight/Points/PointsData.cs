using UnityEngine;

namespace Source.Fight.Points
{
    [CreateAssetMenu(fileName = "RewardsData", menuName = "Immortal_Island/Rewards Data", order = 0)]
    public class PointsData : ScriptableObject
    {
        [SerializeField] private int _pointsForWin;
        [SerializeField] private int _pointsPerSecond;
        [SerializeField] private int _pointsPerSkeletonKilled;
        
        public int PointsForWin => _pointsForWin;

        public int PointsPerSecond => _pointsPerSecond;
        public int PointsPerSkeletonKilled => _pointsPerSkeletonKilled;
    }
}