using UnityEngine;

namespace Source.Fight
{
    public class ExplosionObject : MonoBehaviour
    {

        public void DestroyMe()
        {
            Destroy(gameObject);
        }
    }
}