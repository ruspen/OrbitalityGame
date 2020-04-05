using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Orbitality.GameModule;

namespace Orbitality.SceneModules.Game
{
    public class GameSceneController : MonoBehaviour
    {
        [SerializeField]
        private GameSceneUIController uiController;

        private IGameController gameController = new GameController();

        void Start()
        {
            uiController.OnBackClick += BackGame;
            uiController.OnPauseClick += PauseGame;
            uiController.OnPlayClick += PlayGame;
            gameController.Init();
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

        }
    }
}

