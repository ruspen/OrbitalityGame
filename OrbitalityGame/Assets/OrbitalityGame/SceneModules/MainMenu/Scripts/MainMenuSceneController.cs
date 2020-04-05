using Orbitality.GlobalModule;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Orbitality.SceneModules.MainMenu
{
    public class MainMenuSceneController : MonoBehaviour
    {
        public MainMenuUIController mainMenuUIController;


        void Start()
        {
            Subscribe();
            CheckSaveGame();
        }


        private void OnDisable()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            mainMenuUIController.OnStartGameButtonClick += StartGame;
            mainMenuUIController.OnLoadGameButtonClick += LoadGame;
        }

        private void Unsubscribe()
        {
            mainMenuUIController.OnStartGameButtonClick -= StartGame;
            mainMenuUIController.OnLoadGameButtonClick -= LoadGame;
        }

        private void StartGame()
        {
            SceneManager.LoadScene(GameData.GAME_SCENE_NAME);
        }

        private void LoadGame()
        {
            GameModule.GameData.LOAD_GAME = true;
            StartGame();
        }

        private void CheckSaveGame()
        {
            if (PlayerPrefs.HasKey(GlobalModule.GameData.PPKEY_HAS_SAVE) && PlayerPrefs.GetString(GlobalModule.GameData.PPKEY_HAS_SAVE) == "true")
            {
                mainMenuUIController.ChangeLoadInteractable(true);
            }
            else
            {
                mainMenuUIController.ChangeLoadInteractable(false);
            }
        }
    }
}


