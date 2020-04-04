using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Orbitality.GameModule.SunModule;
using Orbitality.GameModule.PlanetModule;
using Orbitality.UtilitiesModule;

namespace Orbitality.GameModule
{
    public class GameController : MonoBehaviour, IGameController
    {
        private OrbitCreator orbitCreator = new OrbitCreator();
        private SunController sunController;
        private IPlanetController mainPlanetController;
        private List<IPlanetController> otherPlanetsController;

        public void Init()
        {
            
        }

        public void StartGame()
        {
            sunController = Instantiate(Resources.Load<SunController>(SunModule.GameData.SUN_PREFAB_PATH));
            string planetPath = PlanetModule.GameData.PLANETS_PREFAB_PATH[Random.Range(0, PlanetModule.GameData.PLANETS_PREFAB_PATH.Count)];
            mainPlanetController = Instantiate(Resources.Load<PlanetController>(planetPath));
            mainPlanetController.Init();
            mainPlanetController.StartMove(orbitCreator.GetFreeOrbit());
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

    }
}

