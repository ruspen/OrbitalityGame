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

        }
    }
}


