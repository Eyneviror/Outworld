using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Outworld.UI.Models
{
    [System.Serializable]
    public class MenuModel
    {
        public SettingsPanel Settings;
        private const string NextLevel = "StandartWorld";

        public void LoadNextLevel()
        {
            SceneManager.LoadScene(NextLevel);
        }

        public void HideSettingsPanel()
        {
            Settings.Hide();
        }

        public void QuitGame()
        {
            Application.Quit();
        }

    }
}
