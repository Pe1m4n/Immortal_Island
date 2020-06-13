using System.Linq;
using UnityEngine;

namespace Source.Fight.Sounds
{
    public class RandomSoundsPlayer : MonoBehaviour
    {
        [SerializeField] private SoundsList _sounds;
        [SerializeField] private AudioSource _source;
        
        public void PlayRandomSound()
        {
            var rnd = new System.Random();
            var clip = _sounds.Sounds.OrderBy(x => rnd.Next()).First();

            _source.clip = clip;
            _source.Play();
        }
    }
}