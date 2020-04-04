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
            gameController.Init();
            gameController.StartGame();
        }

        
        void Update()
        {

        }
    }
}

