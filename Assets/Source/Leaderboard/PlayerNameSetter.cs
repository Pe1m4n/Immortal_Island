using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Source.Leaderboard
{
    public class PlayerNameSetter : MonoBehaviour
    {
        private PlayerNameHolder _nameHolder;
        
        [SerializeField] private InputField _nameInputField;
        [SerializeField] private GameObject _nextWindow;
        
        [Inject]
        public void SetUp(PlayerNameHolder nameHolder)
        {
            _nameHolder = nameHolder;
        }

        public void TrySetName()
        {
            if (_nameHolder.SetName(_nameInputField.text))
            {
                _nextWindow.SetActive(true);
            }
        }
    }
}