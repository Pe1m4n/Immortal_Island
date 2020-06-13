using UnityEngine;

namespace Source.Common
{
    public class SceneLoaderComponent : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneLoader.Instance.LoadScene(sceneName);
        }
    }
}