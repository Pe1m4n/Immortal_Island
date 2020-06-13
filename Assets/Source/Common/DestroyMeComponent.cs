using UnityEngine;

namespace Source.Common
{
    public class DestroyMeComponent : MonoBehaviour
    {
        [SerializeField] private float _destroyAfterSeconds;

        private float _currentTime;
        
        private void Update()
        {
            if (_currentTime >= _destroyAfterSeconds)
            {
                Destroy(gameObject);
            }

            _currentTime += Time.deltaTime;
        }
    }
}