using UnityEngine;
using UnityEngine.UI;

namespace Source.Leaderboard
{
    public class PlayerNameHolder
    {
        private const string PLAYER_NAME_PREFS = "PlayerName";
        public string Name { get; set; }

        public bool ShouldEnterName()
        {
            if (PlayerPrefs.HasKey(PLAYER_NAME_PREFS))
            {
                Name = PlayerPrefs.GetString(PLAYER_NAME_PREFS);
                return false;
            }

            return true;
        }
        
        public bool SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            Name = name;
            PlayerPrefs.SetString(PLAYER_NAME_PREFS, Name);
            return true;
        }
    }
}