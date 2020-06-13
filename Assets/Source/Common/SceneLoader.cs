using UnityEngine.SceneManagement;
using Zenject;

namespace Source.Common
{
    public class SceneLoader
    {
        private readonly ZenjectSceneLoader _sceneLoader;
        private readonly InputHandlingBlocker _inputHandlingBlocker;
        public static SceneLoader Instance { get; set; }

        public SceneLoader(ZenjectSceneLoader sceneLoader, InputHandlingBlocker inputHandlingBlocker)
        {
            _sceneLoader = sceneLoader;
            _inputHandlingBlocker = inputHandlingBlocker;
            Instance = this;
        }

        public void LoadScene(string sceneName)
        {
            _sceneLoader.LoadScene(sceneName);
        }

        public void ReloadScene()
        {
            _sceneLoader.LoadScene(SceneManager.GetActiveScene().name);
            _inputHandlingBlocker.SetAllowedInputs(InputSource.Cannon);
        }
    }
}