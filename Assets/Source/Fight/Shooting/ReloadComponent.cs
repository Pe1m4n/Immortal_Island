using UnityEngine;

namespace Source.Fight
{
    public class ReloadComponent
    {
        private readonly CannonSettings _settings;

        public bool CanShoot => Time.time > _nextShotTime;

        private float _nextShotTime = float.MinValue;

        public ReloadComponent(CannonSettings settings)
        {
            _settings = settings;
        }

        public void OnShot()
        {
            _nextShotTime = Time.time + _settings.ReloadSeconds;
        }
    }
}