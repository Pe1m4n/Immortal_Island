using System.Linq;
using UnityEngine;

namespace Source.Fight.Sounds
{
    public class RandomSoundsPlayer : MonoBehaviour
    {
        [SerializeField] private SoundsList _sounds;
        [SerializeField] private AudioSource _source;

        [SerializeField] private bool _playOnAwake;

        private void Awake()
        {
            if (!_playOnAwake)
            {
                return;
            }
            
            PlayRandomSound();
        }
        
        public void PlayRandomSound()
        {
            var rnd = new System.Random();
            var clip = _sounds.Sounds.OrderBy(x => rnd.Next()).First();

            _source.clip = clip;
            _source.Play();
        }
    }
}