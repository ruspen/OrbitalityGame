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
        public event Action OnWin;
        public event Action OnLose;

        private OrbitCreator orbitCreator = new OrbitCreator();
        private SunController sunController;
        private IPlanetController mainPlanetController;
        private Dictionary<int, IAIBotController> bots = new Dictionary<int, IAIBotController>();
        private IGameUIController gameUIController;
        private RocketType mainRocketType;
        private int mainPlanetID;
        private bool isDied = false;
        private int botsCount = 0;

        private SaveDataJson saveData = new SaveDataJson();
        private SaveController saveController = new SaveController();


        public void Init()
        {
            
        }

        public void StartGame()
        {
            sunController = Instantiate(Resources.Load<SunController>(SunModule.GameData.SUN_PREFAB_PATH));
            Debug.Log(GameData.LOAD_GAME);
            if (GameData.LOAD_GAME)
            {
                saveData = saveController.GetLastSave();
                CreateBots(true, 1);
                CreateMainPlanet(true);
                CreateBots(true, saveData.Bots.Length - 1);
                CreateGameUI(true);
            }
            else
            {
                CreateBots(false, 1);
                CreateMainPlanet(false);
                CreateBots(false, UnityEngine.Random.Range(GameData.MIN_BOTS, GameData.MAX_BOTS));
                CreateGameUI(false);

            }
            //CreateGameUI();

        }

        public void SaveGame()
        {
            saveData.Main.PlanetID = mainPlanetID;
            saveData.Main.RocketID = (int)mainRocketType;
            saveData.Main.Health = mainPlanetController.GetHeath();
            saveData.Bots = new CharacterParameters[bots.Count];
            for (int i = 0; i < saveData.Bots.Length; i++)
            {
                saveData.Bots[i] = bots[i].GetCharacterParameters();
            }

            saveController.SaveGame(saveData);
            PlayerPrefs.SetString(GlobalModule.GameData.PPKEY_HAS_SAVE, "true");
        }


        private void EndGame(bool win)
        {
            gameUIController.TurnOfRocketButton();
            PlayerPrefs.SetString(GlobalModule.GameData.PPKEY_HAS_SAVE, "false");
            if (win)
            {
                OnWin?.Invoke();
            }
            else
            {
                OnLose?.Invoke();
            }

        }

        private void CreateMainPlanet( bool load)
        {
            float currentHealth;
            if (load)
            {
                mainPlanetID = saveData.Main.PlanetID;
                mainRocketType = (RocketType)saveData.Main.RocketID;
                currentHealth = saveData.Main.Health;
            }
            else
            {
                mainPlanetID = UnityEngine.Random.Range(0, PlanetModule.GameData.PLANETS_PREFAB_PATH.Count);
                mainRocketType = (RocketType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(RocketType)).Length);
                currentHealth = PlanetModule.GameData.PLANET_MAX_HEALTH;
            }
            string planetPath = PlanetModule.GameData.PLANETS_PREFAB_PATH[mainPlanetID];
            mainPlanetController = Instantiate(Resources.Load<PlanetController>(planetPath));
            mainPlanetController.Init(mainRocketType, currentHealth, true);
            mainPlanetController.OnDied += Die;
            mainPlanetController.StartMove(orbitCreator.GetFreeOrbit());
            
            
        }

        private void CreateBots(bool load, int count)
        {
            IPlanetController planetController;
            for (int i = 0; i < count; i++)
            {
                float currentHealth;
                int botPlanetID;
                RocketType botRocketType;
                if (load)
                {
                    currentHealth = saveData.Bots[i].Health;
                    botPlanetID = saveData.Bots[i].PlanetID;
                    botRocketType = (RocketType)saveData.Bots[i].RocketID;
                }
                else
                {
                    currentHealth = PlanetModule.GameData.PLANET_MAX_HEALTH;
                    botPlanetID = UnityEngine.Random.Range(0, PlanetModule.GameData.PLANETS_PREFAB_PATH.Count);
                    botRocketType = (RocketType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(RocketType)).Length);
                }
                string planetPath = PlanetModule.GameData.PLANETS_PREFAB_PATH[botPlanetID];
                planetController = Instantiate(Resources.Load<PlanetController>(planetPath));
                planetController.Init(botRocketType, currentHealth);
                planetController.StartMove(orbitCreator.GetFreeOrbit());
                IAIBotController bot = new AIBotController();
                bot.Init(bots.Count, planetController, botPlanetID, (int)botRocketType);
                bots.Add(bots.Count, bot);
                botsCount++;
                bot.OnDied += (id) =>
                {
                    //bots.Remove(id);
                    botsCount--;
                    SomeoneDie();
                };
            }
        }

        private void CreateGameUI(bool load)
        {
            gameUIController = Instantiate(Resources.Load<GameUIController>(GameUIModule.GameData.GAMEUICANVAS_PATH));
            gameUIController.Init(PlanetModule.GameData.PLANET_MAX_HEALTH, mainRocketType);
            gameUIController.onClickRocketButton += mainPlanetController.Attack;
            mainPlanetController.OnHealthChanged += gameUIController.ChangeHealth;
            if (load)
            {
                gameUIController.ChangeHealth(saveData.Main.Health);
            }
            for (int i = 0; i < bots.Count; i++)
            {
                gameUIController.AddBotHealth(i, bots[i].GetCharacterParameters().Health);
                bots[i].OnChangeHealth += gameUIController.ChangeBotHealth;
                if (load)
                {
                    gameUIController.ChangeBotHealth(i, saveData.Bots[i].Health);
                }
            }
        }

        private void SomeoneDie()
        {
            Debug.Log($"Someone Die Now we have {bots.Count} bots");
            if (botsCount == 0 && !isDied)
            {
                EndGame(true);
            }
        }

        private void Die()
        {
            isDied = true;
            EndGame(false);
        }
    }
}

