using System.Collections.Generic;
using UnityEngine;

namespace Source.Fight.Sounds
{
    [CreateAssetMenu(fileName = "SoundsList", menuName = "Immortal_Island/Sounds List", order = 0)]
    public class SoundsList : ScriptableObject
    {
        [SerializeField] private List<AudioClip> _sounds;

        public List<AudioClip> Sounds => _sounds;
    }
}