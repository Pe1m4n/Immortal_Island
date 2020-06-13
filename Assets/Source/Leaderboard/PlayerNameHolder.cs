using UnityEngine;

namespace Source.Leaderboard
{
    public class PlayerNameHolder
    {
        private readonly GameObject _enterNameDialog;
        private const string PLAYER_NAME_PREFS = "PlayerName";
        public string Name { get; set; }

        public PlayerNameHolder(GameObject enterNameDialog)
        {
            _enterNameDialog = enterNameDialog;
            if (PlayerPrefs.HasKey(PLAYER_NAME_PREFS))
            {
                Name = PlayerPrefs.GetString(PLAYER_NAME_PREFS);
                return;
            }
            
            ShowEnterNameDialog();
        }

        public void ShowEnterNameDialog()
        {
            _enterNameDialog.SetActive(true);
        }
        
        public void SetName(string name)
        {
            Name = name;
        }
    }
}