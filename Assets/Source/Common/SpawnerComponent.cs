using UnityEngine;

namespace Source.Common
{
    public class SpawnerComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject; 

        public void Spawn()
        {
            if (_gameObject == null)
            {
                return;
            }

            Instantiate(_gameObject, transform.position, transform.rotation, null);
        }
    }
}