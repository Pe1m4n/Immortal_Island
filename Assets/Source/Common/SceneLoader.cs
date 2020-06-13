using UnityEngine.SceneManagement;
using Zenject;

namespace Source.Common
{
    public class SceneLoader
    {
        private readonly ZenjectSceneLoader _sceneLoader;
        public static SceneLoader Instance { get; set; }

        public SceneLoader(ZenjectSceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            Instance = this;
        }

        public void LoadScene(string sceneName)
        {
            _sceneLoader.LoadScene(sceneName);
        }

        public void ReloadScene()
        {
            _sceneLoader.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}