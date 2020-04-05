using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Orbitality.GameModule;
using UnityEngine.SceneManagement;

namespace Orbitality.SceneModules.Game
{
    public class GameSceneController : MonoBehaviour
    {
        [SerializeField]
        private GameSceneUIController uiController;

        private bool endGame = false;
        private IGameController gameController = new GameController();

        void Start()
        {
            uiController.OnBackClick += BackGame;
            uiController.OnPauseClick += PauseGame;
            uiController.OnPlayClick += PlayGame;
            gameController.Init();
            gameController.OnWin += Win;
            gameController.OnLose += Lose;
            gameController.StartGame();
        }

        
        void Update()
        {

        }


        private void PauseGame()
        {
            Time.timeScale = 0;
        }

        private void PlayGame()
        {
            Time.timeScale = 1;
        }

        private void BackGame()
        {
            if (!endGame)
            {
                gameController.SaveGame();
            }
            SceneManager.LoadScene(GlobalModule.GameData.MAINMENU_SCENE_NAME);
        }

        private void Win()
        {
            uiController.ShowWin();
            endGame = true;
        }

        private void Lose()
        {
            uiController.ShowLose();
            endGame = true;
        }

    }
}

