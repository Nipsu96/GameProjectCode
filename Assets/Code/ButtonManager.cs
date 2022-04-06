using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Polar
{
    public class ButtonManager : MonoBehaviour
    {
        private string mainMenuName = "MainMenu";
        private string kauppahalliName = "Kauppahalli";
		private string optionsName = "OptionsMenu";
		private string scoreboardName = "ScoreboardMenu";
		private GameObject mainMenu;
        private GameObject optionsMenu;
        private GameObject scoreboardMenu;

		private void Awake()
		{
			//Debug.LogWarning("Awake");
		}

		private void Start()
        {
			//Debug.LogWarning("Start");
            FindMainMenu();
            FindOptionsMenu();
            FindScoreboardMenu();
			SetCorrectUIPanels();
		}

        private void SetCorrectUIPanels()
        {
            if (!mainMenu.activeInHierarchy)
            {
                mainMenu.SetActive(true);
            }

            if (optionsMenu.activeInHierarchy)
            {
                optionsMenu.SetActive(false);
            }

            if (scoreboardMenu.activeInHierarchy)
            {
                scoreboardMenu.SetActive(false);
            }
        }

        public void OnPlayGame()
        {
            SceneManager.LoadScene(kauppahalliName);
        }
        public void OnOptions()
        {
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
        }
        public void OnScoreboard()
        {
            mainMenu.SetActive(false);
            scoreboardMenu.SetActive(true);
        }
        public void OnQuit()
        {
            Application.Quit();
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }

        public void OnBackToMainMenu()
        {
            if (scoreboardMenu.activeInHierarchy)
            {
                scoreboardMenu.SetActive(false);
            }
            if (optionsMenu.activeInHierarchy)
            {
                optionsMenu.SetActive(false);
            }
            mainMenu.SetActive(true);
        }

        private void FindMainMenu()
        {
            if (mainMenu == null)
            {
                mainMenu = transform.Find(mainMenuName).gameObject;
            }
        }

        private void FindOptionsMenu()
        {
            if (optionsMenu == null)
            {
                optionsMenu = transform.Find(optionsName).gameObject;
            }
        }

        private void FindScoreboardMenu()
        {
            if (scoreboardMenu == null)
            {
                scoreboardMenu = transform.Find(scoreboardName).gameObject;
            }
        }
    }
}
