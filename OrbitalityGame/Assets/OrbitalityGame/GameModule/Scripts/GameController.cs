using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Orbitality.GameModule.SunModule;
using Orbitality.GameModule.PlanetModule;
using Orbitality.UtilitiesModule;
using System;
using UnityEngine.UIElements;
using Orbitality.GameModule.GameUIModule;
using Orbitality.GameModule.AIBotModule;

namespace Orbitality.GameModule
{
    public class GameController : MonoBehaviour, IGameController
    {
        private OrbitCreator orbitCreator = new OrbitCreator();
        private SunController sunController;
        private IPlanetController mainPlanetController;
        private Dictionary<int, IAIBotController> bots = new Dictionary<int, IAIBotController>();
        private IGameUIController gameUIController;
        private RocketType mainRocketType;

        public void Init()
        {
            
        }

        public void StartGame()
        {
            sunController = Instantiate(Resources.Load<SunController>(SunModule.GameData.SUN_PREFAB_PATH));
            CreateBots(1);
            CreateMainPlanet();
            CreateBots(UnityEngine.Random.Range(GameData.MIN_BOTS, GameData.MAX_BOTS));
            CreateGameUI();
        }

        public void Play()
        {
            
        }

        public void Pause()
        {
            
        }

        public void EndGame()
        {
            throw new System.NotImplementedException();
        }

        public void SaveGame()
        {
            throw new NotImplementedException();
        }

        private void CreateMainPlanet()
        {
            string planetPath = PlanetModule.GameData.PLANETS_PREFAB_PATH[UnityEngine.Random.Range(0, PlanetModule.GameData.PLANETS_PREFAB_PATH.Count)];
            mainPlanetController = Instantiate(Resources.Load<PlanetController>(planetPath));
            mainRocketType = (RocketType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(RocketType)).Length);
            mainPlanetController.Init(mainRocketType, true);
            mainPlanetController.StartMove(orbitCreator.GetFreeOrbit());
        }

        private void CreateBots(int count)
        {
            IPlanetController planetController;
            for (int i = 0; i < count; i++)
            {
                string planetPath = PlanetModule.GameData.PLANETS_PREFAB_PATH[UnityEngine.Random.Range(0, PlanetModule.GameData.PLANETS_PREFAB_PATH.Count)];
                planetController = Instantiate(Resources.Load<PlanetController>(planetPath));
                planetController.Init(mainRocketType);
                planetController.StartMove(orbitCreator.GetFreeOrbit());
                IAIBotController bot = new AIBotController();
                bot.Init(bots.Count, planetController);
                bots.Add(bots.Count, bot);
                bot.OnDied += (id) =>
                {
                    bots.Remove(id);
                    SomeoneDie();
                };
            }
        }

        private void CreateGameUI()
        {
            gameUIController = Instantiate(Resources.Load<GameUIController>(GameUIModule.GameData.GAMEUICANVAS_PATH));
            gameUIController.Init(100, mainRocketType);
            gameUIController.onClickRocketButton += mainPlanetController.Attack;
            mainPlanetController.OnHealthChanged += gameUIController.ChangeHealth;
            foreach (var bot in bots)
            {
                gameUIController.AddBotHealth(bot.Key, PlanetModule.GameData.PLANET_MAX_HEALTH);
                bot.Value.OnChangeHealth += gameUIController.ChangeBotHealth;
            }
        }

        private void SomeoneDie()
        {
            Debug.Log($"Someone Die Now we have {bots.Count} bots");
            if (bots.Count == 0)
            {
                EndGame();
            }
        }
    }
}

